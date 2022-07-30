using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace justch.Models.Service
{
    public class CryptageEncryptage
    {
        public static string key = "bako@4560";

        public static  string Encrypte(string passsword) {
            if (string.IsNullOrEmpty(passsword)) return null;
            else
                passsword += key;
            var passwordByte = Encoding.UTF8.GetBytes(passsword);
            return Convert.ToBase64String(passwordByte);

        
        }
        public static string decrypte(string passswordencrype)
        {
            if (string.IsNullOrEmpty(passswordencrype)) return null;
        
               
            var passwordByte = Convert.FromBase64String(passswordencrype);
            var   Result= Encoding.UTF8.GetString(passwordByte);
            Result = Result.Substring(0, Result.Length - key.Length);
            return Result;


        }

    }
}
