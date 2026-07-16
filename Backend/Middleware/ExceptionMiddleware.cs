using System.Text.Json;
using Backend.Exceptions;

namespace Backend.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ProductoNoEncontradoException ex)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            context.Response.ContentType = "application/json";

            var respuesta = new
            {
                mensaje = ex.Message
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(respuesta)
            );
        }
        catch (Exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Response.ContentType = "application/json";

            var respuesta = new
            {
                mensaje = "Ha ocurrido un error interno."
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(respuesta)
            );
        }
    }
}