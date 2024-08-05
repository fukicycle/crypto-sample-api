namespace crypto_api.Endpoints;

public abstract class EndpointFactory
{
    public static void RegisterAll(WebApplication app)
    {
        EndpointFactory endpointFactory = new CryptoEndpoint();
        endpointFactory.Register(app);
    }
    protected abstract void Register(WebApplication app);
}
