using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EncryptionLibrary
{
    public class RSA
    {
        /// <summary>
        /// шифрование данных с помощью реализации алгоритма RSA
        /// </summary>
        /// <param name="data">строка для шифрования</param>
        /// <returns>зашифрованниая строка</returns>
        public static string Encrypt(string data)
        {
            string encryptedString = "";
            try
            {
                UnicodeEncoding ByteConverter = new UnicodeEncoding();

                byte[] dataForEncryption = ByteConverter.GetBytes(data);
                byte[] encryptedData;

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    encryptedData = RSAEncrypt(dataForEncryption, RSA.ExportParameters(false), false);
                }
                encryptedString = encryptedData.ToString();
            }
            catch (ArgumentNullException)
            {
                encryptedString = "Encryption failed";
            }
            return encryptedString;
        }

        /// <summary>
        /// расшифровка данных с помощью реализации алгоритма RSA
        /// </summary>
        /// <param name="data">зашифрованная строка</param>
        /// <returns>расшифрованная строка</returns>
        public static string Decrypt(string data)
        {
            string decryptedString = "";
            try
            {
                UnicodeEncoding ByteConverter = new UnicodeEncoding();

                byte[] decryptionData = ByteConverter.GetBytes(data);
                byte[] decryptedData;

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    decryptedData = RSADecrypt(decryptionData, RSA.ExportParameters(true), false);
                }
                decryptedString = decryptedData.ToString();
            }
            catch (ArgumentNullException)
            {
                decryptedString = "Encryption failed";
            }
            return decryptedString;
        }

        private static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKeyInfo);
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }

            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKeyInfo);
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }

            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
