using crypto_api.DTO;
using crypto_api.Services;

namespace crypto_api.Endpoints;

public class CryptoEndpoint : IEndpoint
{
    private static CryptoEndpoint _instance = new CryptoEndpoint();
    private CryptoEndpoint() { }
    public static IEndpoint Initialize()
    {
        return _instance;
    }

    public void Register(WebApplication app)
    {
        var baseApp = app.MapGroup("/api/v1");

        baseApp.MapPost("/encrypt", (ICryptoService cryptoService, CryptoDTO cryptoDTO) =>
        {
            if (string.IsNullOrEmpty(cryptoDTO.Content))
            {
                return Results.BadRequest();
            }
            try
            {
                return Results.Ok(cryptoService.Encrypt(cryptoDTO.Content));
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        });

        baseApp.MapPost("/decrypt", (ICryptoService cryptoService, CryptoDTO cryptoDTO) =>
        {
            if (string.IsNullOrEmpty(cryptoDTO.Content))
            {
                return Results.BadRequest();
            }
            try
            {
                return Results.Ok(cryptoService.Decrypt(cryptoDTO.Content));
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        });
    }
}
