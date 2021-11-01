using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace HPCL_DP_Terminal.MQSupportClass
{
    public class TokenManager
    {

        public class ReturnGenerateTokenStatusOutput
        {

            [JsonProperty("Success")]
            public bool Success { get; set; }

            [JsonProperty("Message")]
            public string Message { get; set; }

            [JsonProperty("Status_Code")]
            public Int64 Status_Code { get; set; }

            [JsonProperty("Method_Name")]
            public string Method_Name { get; set; }

            [JsonProperty("Token")]
            public string Token { get; set; }

            [JsonProperty("Model_State")]
            public ModelStateDictionary Model_State { get; set; }
        }

        //private static string Secret = Guid.NewGuid().ToString();
        public static string Secret = string.Empty;
        public static string GenerateToken(string Useragent, string Userip)
        {
            byte[] key = Convert.FromBase64String(Secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                      new Claim(ClaimTypes.Name, Useragent)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = Userip,
                Audience = Userip,
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
        public static ClaimsPrincipal GetPrincipal(string token, string Useragent, string Userip)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Convert.FromBase64String(Secret);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    NameClaimType = Useragent,
                    RequireExpirationTime = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidIssuer = Userip,
                    ValidAudience = Userip,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };


                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out SecurityToken securityToken);
                return principal;


            }
            catch
            {
                return null;
            }
        }
        public static string ValidateToken(string token, string Useragent, string Userip)
        {
            ClaimsPrincipal principal = GetPrincipal(token, Useragent, Userip);
            if (principal == null)
                return null;
            ClaimsIdentity identity;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            string username = usernameClaim.Value;
            return username;
        }


        public class GenerateTokenInput
        {

            [JsonProperty("Useragent")]
            public string Useragent { get; set; }

            [JsonProperty("Userip")]
            public string Userip { get; set; }

            [JsonProperty("Userid")]
            public string Userid { get; set; }

        }

    }
}