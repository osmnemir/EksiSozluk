using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.Common.Infrastructure
{
    public class PasswordEncryptor
    {
        public static string Encrpt(string password)    // içine passweordu yolladık 
        {
            using var md5 = MD5.Create(); // md5 classı var ekliyoruz (kütüphene)

            byte[] inputBytes = Encoding.ASCII.GetBytes(password);  // dışardan yazmış olduğumuz paswordu byte arraya çevirme işlemi yapcak ASCII sayesinde
            byte[] hashBytes = md5.ComputeHash(inputBytes); // Haslanmiş bytlere çeviriyor. Şifrelenmiş dataya çeviriyor yukardakinden farkı bu.

            return Convert.ToHexString(hashBytes); // şifrelenmiş datayı strginge çevirip döndürme işlemi yapar
        }
    }
}
