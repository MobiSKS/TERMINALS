using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;

public class Variables
{

    public Variables()
    {

    }

    public string FunGenerateStringUId()
    {
        byte[] bytBuffer = Guid.NewGuid().ToByteArray();
        return BitConverter.ToInt64(bytBuffer, 0).ToString();
    }
    public string GetConnection()
    {
        return ConfigurationManager.AppSettings["ConnectionString"].ToString();
    }
    public bool Chk_APIKey_Validation(string API_Key)
    {
        if (API_Key == StrAPI_Key)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Chk_SecretKey_Validation(string Secret_Key)
    {
        if (Secret_Key == StrSecretKey)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Chk_API_Key_SecretKey_Validation(string API_Key, string Secret_Key)
    {
        if (Secret_Key == StrSecretKey && API_Key == StrAPI_Key)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public static void PostSMSRequest(string Url, out string Result)
    {
        string Ststus = string.Empty;
        try
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                Ststus = reader.ReadToEnd();

            }
        }
        catch (Exception ex)
        {
            Ststus = ex.Message;
        }
        Result = Ststus;
    }

    public static bool IsPhoneNumber(string number)
    {
        //return Regex.Match(number, @"^(\+[6-9]{10})$").Success;
        string CheckMobileNo = number.Substring(0, 1);
        bool IsResult;
        if (CheckMobileNo.Contains('6') || CheckMobileNo.Contains('7') || CheckMobileNo.Contains('8') || CheckMobileNo.Contains('9'))
            IsResult = true;
        else
            IsResult = false;
        return IsResult;
    }

    public static string RightString(string value, int length)
    {
        return value.Substring(value.Length - length);
    }

    public string StrStoreCode
    {
        get
        {
            return ConfigurationManager.AppSettings["StoreCode"].Trim().ToString();
        }
    }

    public string StrSecretKey
    {
        get
        {
            return ConfigurationManager.AppSettings["SecretKey"].Trim().ToString();
        }
    }

    public string StrAPI_Key
    {
        get
        {
            return ConfigurationManager.AppSettings["API_Key"].Trim().ToString();
        }
    }

}