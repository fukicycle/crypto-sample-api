using crypto_api.DTO;
using crypto_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace crypto_api.Endpoints;

public class CryptoEndpoint : EndpointFactory
{
    protected override void Register(WebApplication app)
    {
        var baseApp = app.MapGroup("/api/v1");

        baseApp.MapPost("/encrypt", Encrypt);
        baseApp.MapPost("/decrypt", Decrypt);
    }

    private IResult Encrypt([FromServices] ICryptoService cryptoService, [FromBody] CryptoDTO cryptoDTO)
    {
        if (string.IsNullOrEmpty(cryptoDTO.Content))
        {
            return TypedResults.BadRequest();
        }
        try
        {
            return TypedResults.Ok(cryptoService.Encrypt(cryptoDTO.Content));
        }
        catch (Exception e)
        {
            return TypedResults.Problem(e.Message);
        }
    }

    private IResult Decrypt([FromServices] ICryptoService cryptoService, [FromBody] CryptoDTO cryptoDTO)
    {
        if (string.IsNullOrEmpty(cryptoDTO.Content))
        {
            return TypedResults.BadRequest();
        }
        try
        {
            return TypedResults.Ok(cryptoService.Decrypt(cryptoDTO.Content));
        }
        catch (Exception e)
        {
            return TypedResults.Problem(e.Message);
        }
    }
}
