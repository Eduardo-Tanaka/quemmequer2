using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AM_QMQ.Utils
{
    public class CriptografiaUtils
    {
        public static string CriptografarSHA256(string password)
        {
            System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = sha256.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(password));
            var senhaHash = Convert.ToBase64String(bytes);
            return senhaHash;
        }
    }
}