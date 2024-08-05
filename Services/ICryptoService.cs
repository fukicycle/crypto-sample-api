namespace crypto_api.Services;

public interface ICryptoService
{
    string Encrypt(string content);
    string Decrypt(string content);
}
