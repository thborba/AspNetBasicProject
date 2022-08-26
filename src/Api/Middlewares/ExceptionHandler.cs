using Api.DTO;
using Newtonsoft.Json;
using System.Net;

namespace Api.Middlewares
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorHandler(RequestDelegate next, ILogger logger)
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
            catch (Exception ex)
            {
                await HandleErrorAsync(context, ex);

            }
        }

        private Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, exception.Message);

            var errorResponse = new ErrorResponse(exception.Message, (int)HttpStatusCode.InternalServerError);

            context.Response.StatusCode = errorResponse.StatusCode;

            return context.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}
