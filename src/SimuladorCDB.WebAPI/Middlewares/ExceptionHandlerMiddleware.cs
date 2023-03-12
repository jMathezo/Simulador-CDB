using SimuladorCDB.Domain.Exceptions;
using SimuladorCDB.WebAPI.Models;
using System.Net;
using System.Text.Json;

namespace SimuladorCDB.WebAPI.Middlewares
{
    public class ExceptionHandlerMiddleware { 

    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            switch (error)
            {
                case AppException:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // unhandled error
                    _logger.LogError(error, error.Message);
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = new ErrorDetails()
            {
                StatusCode = response.StatusCode,
                Message = error.Message
            }.ToString();

            await response.WriteAsync(result);
        }
    }
}
}
