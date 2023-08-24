using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ShareLibrary.DataProviders;

public class EncriptionProvider : IEncriptionProvider
{
    #region [ CTor ]
    public EncriptionProvider()
    {

    }
    #endregion

    #region [ Methods - Encrypt ]
    public string Encrypt(string text, string salt)
    {
        var result = string.Empty;
        var key = salt.Substring(0, 16);
        var iv = new byte[16];
        byte[] array;

        using (var aes = Aes.Create())
        {

            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (var ms = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream((Stream)ms, encryptor, CryptoStreamMode.Write))
                {
                    using (var streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(text);
                    }
                    array = ms.ToArray();
                }
            }
        }
        result = Convert.ToBase64String(array);

        return result;
    }

    public string Decrypt(string text, string salt)
    {
        var result = string.Empty;
        var key = salt.Substring(0, 16);
        var iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(text);

        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using (var ms = new MemoryStream(buffer))
            {
                using (var cryptoStream = new CryptoStream((Stream)ms, decryptor, CryptoStreamMode.Read))
                {
                    using (var streamReader = new StreamReader(cryptoStream))
                    {
                        result = streamReader.ReadToEnd();
                    }
                }
            }
        }

        return result;
    }
    #endregion

    #region [ Methods - Hash ]
    public string HashWithSalt(string textString, string saltString)
    {
        var result = string.Empty;

        var algorithm = SHA512.Create();
        var plainText = Encoding.UTF8.GetBytes(textString);
        var salt = Encoding.UTF8.GetBytes(saltString);

        byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

        for (int i = 0; i < plainText.Length; i++)
        {
            plainTextWithSaltBytes[i] = plainText[i];
        }
        for (int i = 0; i < salt.Length; i++)
        {
            plainTextWithSaltBytes[plainText.Length + i] = salt[i];
        }

        var resultByte = algorithm.ComputeHash(plainTextWithSaltBytes);

        result = Convert.ToBase64String(resultByte);
        return result;
    }
    #endregion
}
