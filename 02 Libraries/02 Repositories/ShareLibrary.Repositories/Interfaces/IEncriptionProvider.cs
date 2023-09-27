namespace ShareLibrary.Repositories;

public interface IEncriptionProvider
{
    string EncryptWithSalt(string text, string key);

    string Decrypt(string text, string key);

    string HashWithSalt(string text, string salt);
}
