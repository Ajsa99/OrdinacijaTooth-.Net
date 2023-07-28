using System.Net;

namespace backend.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Obrada request-a i hvatanje grešaka unutar sledećih middleware-a u lancu
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Unhandled error occurred");

                // Handle the error and generate a response
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var errorMessage = "An internal server error occurred. Please try again later.";
                await context.Response.WriteAsync(errorMessage);
            }
        }
    }
}
