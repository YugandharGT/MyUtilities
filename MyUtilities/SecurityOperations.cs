using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MyUtilities
{
    public class SecurityOperations
    {
          
        private static byte[] _key =
        {
            1,23,51,51,5,96,13,
            133,194,12,22,14,7,18,
            1,96,17,38,141,17,12,9,
            8,4,9,1,3,87,52,17,11,7
        };

        private static byte[] _iv =
        {
            110,1,25,12,127,10,8,28,
            131,12,16,21,17,4,2,8
        };

        public string EncryptString(string src)
        {

            byte[] p = Encoding.ASCII.GetBytes(src.ToCharArray());
            byte[] encodedBytes = { };

            MemoryStream ms = new MemoryStream();
            Aes rv = new AesCng();
            CryptoStream cs = new CryptoStream(ms, rv.CreateEncryptor(_key, _iv), CryptoStreamMode.Write);

            try
            {
                cs.Write(p, 0, p.Length);
                cs.FlushFinalBlock();
                encodedBytes = ms.ToArray();
            }
            catch(Exception exc)
            {
                throw exc;
            }
            finally
            {
                ms.Close();
                cs.Close();
            }

            return Convert.ToBase64String(encodedBytes);

        }

        public string DecryptString(string src)
        {          
            try
            {

                byte[] p = Convert.FromBase64String(src);
                byte[] initialText = new byte[p.Length];

                Aes rv = new AesCng();
                MemoryStream ms = new MemoryStream(p);
                CryptoStream cs = new CryptoStream(ms, rv.CreateDecryptor(_key, _iv), CryptoStreamMode.Read);

                try
                {
                    cs.Read(initialText, 0, initialText.Length);
                }
                finally
                {
                    ms.Close();
                    cs.Close();
                }

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < initialText.Length; ++i)
                {
                    if (initialText[i] > 0)
                    {
                        sb.Append((char)initialText[i]);
                    }
                }

                return sb.ToString();
            }
            catch (Exception exc)
            { 
                throw exc; 
            }
        }

    }
}
    