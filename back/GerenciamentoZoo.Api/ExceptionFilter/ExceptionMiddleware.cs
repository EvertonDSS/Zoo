using GerenciamentoZoo.Domain.ExceptionConfig;

namespace GerenciamentoZoo.Api.ExceptionFilter
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex) // Captura exceções de domínio
            {
                await HandleExceptionAsync(context, ex.Message, ex.StatusCode);
            }
            catch (Exception ex) // Captura exceções inesperadas
            {
                await HandleExceptionAsync(context, "Ocorreu um erro inesperado.", 500);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, string message, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new
            {
                message = message,
                statusCode = statusCode
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
