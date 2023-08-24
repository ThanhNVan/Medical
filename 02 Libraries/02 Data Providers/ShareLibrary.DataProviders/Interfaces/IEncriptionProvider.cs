namespace ShareLibrary.DataProviders;

public interface IEncriptionProvider
{
    string Encrypt(string text, string key);

    string Decrypt(string text, string key);
}
