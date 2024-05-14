using System.Text;
using System.Security.Cryptography;

namespace Example02.IdentityWebApp.Helpers
{
    public static class Sifreleme
    {
        public static string Md5Hash(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            // asd123 => 

            byte[] dizi = Encoding.UTF8.GetBytes(text);

            dizi = md5.ComputeHash(dizi);

            //string passHash = "";
            StringBuilder sb = new StringBuilder();

            foreach (byte b in dizi)
            {
                //passHash += b.ToString("X2").ToLower();

                sb.Append(b.ToString("X2").ToLower());
            }

            //return passHash;

            return sb.ToString();
        }
    }
}
