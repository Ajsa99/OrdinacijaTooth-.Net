using System.Diagnostics;

namespace backend.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<LoggingMiddleware> logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                // Pre obrade requesta
                logger.LogInformation($"Request {context.Request.Method} {context.Request.Path} received.");

                // Poziv sledećeg middleware-a u lancu
                await next(context);

                // Posle obrade requesta
                stopwatch.Stop();
                logger.LogInformation($"Request {context.Request.Method} {context.Request.Path} completed in {stopwatch.ElapsedMilliseconds} ms.");
            }
            catch
            {
                // Ignorišemo greške u ovom middleware-u, jer će se one obraditi u GlobalErrorHandlingMiddleware
                await next(context);
            }
        }
    }
}
