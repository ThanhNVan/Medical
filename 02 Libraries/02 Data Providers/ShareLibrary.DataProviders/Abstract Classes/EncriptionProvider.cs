using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShareLibrary.DataProviders;

public class EncriptionProvider : IEncriptionProvider
{
    #region [ CTor ]
    public EncriptionProvider()
    {

    }
    #endregion

    #region [ Methods -  ]
    public string Encrypt(string text, string key)
    {
        var result = string.Empty;

        var iv = new byte[16];
        byte[] array;

        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream();
            using var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using var streamWriter = new StreamWriter(cryptoStream);

            streamWriter.Write(text);

            array = ms.ToArray();
        }
        result = Convert.ToBase64String(array);

        return result;
    }

    public string Decrypt(string text, string key)
    {
        var result = string.Empty;

        var iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(text);

        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(buffer);
            using var cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoStream);

            result = streamReader.ReadToEnd();
        }

        return result;
    }
    #endregion
}
