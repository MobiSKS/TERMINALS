using HPCL_DP_Terminal.Helpers;
using HPCL_DP_Terminal.MQSupportClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using static HPCL_DP_Terminal.Models.EncryptRequest;
using static HPCL_DP_Terminal.MQSupportClass.StatusMessage;

namespace HPCL_DP_Terminal.Controllers
{

	public class PKCSKeyGenerator
	{
		byte[] key = new byte[8], iv = new byte[8];
		DESCryptoServiceProvider des = new DESCryptoServiceProvider();

		public byte[] Key { get { return key; } }
		public byte[] IV { get { return IV; } }
		public ICryptoTransform Encryptor { get { return des.CreateEncryptor(key, iv); } }

		public PKCSKeyGenerator() { }
		public PKCSKeyGenerator(String keystring, byte[] salt, int md5iterations, int segments)
		{
			Generate(keystring, salt, md5iterations, segments);
		}

		public ICryptoTransform Generate(String keystring, byte[] salt, int md5iterations, int segments)
		{
			int HASHLENGTH = 16;    //MD5 bytes
			byte[] keymaterial = new byte[HASHLENGTH * segments];     //to store contatenated Mi hashed results

			// --- get secret password bytes ----
			byte[] psbytes;
			psbytes = Encoding.UTF8.GetBytes(keystring);

			// --- contatenate salt and pswd bytes into fixed data array ---
			byte[] data00 = new byte[psbytes.Length + salt.Length];
			Array.Copy(psbytes, data00, psbytes.Length);        //copy the pswd bytes
			Array.Copy(salt, 0, data00, psbytes.Length, salt.Length);   //concatenate the salt bytes

			// ---- do multi-hashing and contatenate results  D1, D2 ...  into keymaterial bytes ----
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] result = null;
			byte[] hashtarget = new byte[HASHLENGTH + data00.Length];   //fixed length initial hashtarget

			for (int j = 0; j < segments; j++)
			{
				// ----  Now hash consecutively for md5iterations times ------
				if (j == 0) result = data00;    //initialize
				else
				{
					Array.Copy(result, hashtarget, result.Length);
					Array.Copy(data00, 0, hashtarget, result.Length, data00.Length);
					result = hashtarget;
				}

				for (int i = 0; i < md5iterations; i++)
					result = md5.ComputeHash(result);

				Array.Copy(result, 0, keymaterial, j * HASHLENGTH, result.Length);  //contatenate to keymaterial
			}

			Array.Copy(keymaterial, 0, key, 0, 8);
			Array.Copy(keymaterial, 8, iv, 0, 8);

			return Encryptor;
		}
		public ICryptoTransform Decryptor
		{
			get
			{
				return des.CreateDecryptor(key, iv);
			}
		}
	}

	public class PBEncryptionDecryption
	{
		public string getPartnerAuthoriationKey(string lmid, string valuestringToEncrypt, string privateKey, string partnerAuthKey)
		{
			string hashKey = "";
			try
			{
				CryptoService cryptoService = new CryptoService();
				string decryptedText = getDecryptedKey(privateKey, partnerAuthKey);
				string encryptedString = cryptoService.encrypt(valuestringToEncrypt + decryptedText);
				hashKey = cryptoService.getHashValue(encryptedString);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return hashKey;
		}

		public static string getDecryptedKey(string secretKey, string encryptedText)
		{
			if (string.IsNullOrEmpty(encryptedText))
			{
				return encryptedText;
			}

			byte[] salt = new byte[]
			{
				(byte)0xA9, (byte)0x9B, (byte)0xC8, (byte)0x32,
				(byte)0x56, (byte)0x35, (byte)0xE3, (byte)0x03
			};

			PKCSKeyGenerator crypto = new PKCSKeyGenerator(secretKey, salt, 19, 1);
			ICryptoTransform cryptoTransform = crypto.Decryptor;

			byte[] cipherBytes = System.Convert.FromBase64String(encryptedText);
			byte[] clearBytes = cryptoTransform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
			return Encoding.UTF8.GetString(clearBytes);
		}

	}

	public class CryptoService
	{
		public string encrypt(String plaintext)
		{
			SHA1 sha = new SHA1Managed();
			UTF8Encoding ue = new UTF8Encoding();
			byte[] data = ue.GetBytes(plaintext);
			byte[] digest = sha.ComputeHash(data);

			return System.Convert.ToBase64String(digest);
		}

		public string getHashValue(string encryptedString)
		{
			var sha1 = SHA1Managed.Create();
			byte[] inputBytes = Encoding.UTF8.GetBytes(encryptedString);
			byte[] outputBytes = sha1.ComputeHash(inputBytes);
			return BitConverter.ToString(outputBytes).Replace("-", "").ToLower().Substring(0, 16);

		}
	}

	public class EncryptRequestController : ApiController
    {
		

		[HttpPost]
		[CustomAuthenticationFilter]
		[Route("api/edc/terminals/encrypt_request")]
		public object Encrypt_Request([FromBody] Encrypt_Request_Input ObjClass)
		{
			if (ObjClass == null)
			{
				return MessageHelper.Message(Request, HttpStatusCode.NotAcceptable, false, (int)StatusInformation.Request_JSON_Body_Is_Null, null);
			}
			else
			{

				PBEncryptionDecryption _encrpt = new PBEncryptionDecryption();
				object EncryptRequest = _encrpt.getPartnerAuthoriationKey(ObjClass.CETTxnMerchantId, ObjClass.ValueStringToEncrypt, 
					ObjClass.PBPrivateKey, ObjClass.PBpartnerAuthKey);

				if (EncryptRequest != null)
					return MessageHelper.Message(Request, HttpStatusCode.OK, true, (int)StatusInformation.Success, EncryptRequest);
				else
					return MessageHelper.Message(Request, HttpStatusCode.OK, false, (int)StatusInformation.Fail, EncryptRequest);
			}

		}


	}
}
