namespace ShareLibrary.EntityProviders;

public interface IEncriptionProvider
{
    string EncryptWithSalt(string text, string key);

    string DecryptWithSalt(string text, string key);

    string HashWithSalt(string text, string salt);
}
