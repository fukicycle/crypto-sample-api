namespace crypto_api.Endpoints;

public interface IEndpoint
{
    extern static IEndpoint Initialize();
    void Register(WebApplication app);
}
