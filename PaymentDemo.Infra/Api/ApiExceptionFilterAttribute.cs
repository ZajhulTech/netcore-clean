using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // sigue con el siguiente middleware
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled Exception: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var response = new
        {
            status = 500,
            message = "Internal Server Error",
            detail = ex.Message // opcional, puedes quitarlo en producción
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}