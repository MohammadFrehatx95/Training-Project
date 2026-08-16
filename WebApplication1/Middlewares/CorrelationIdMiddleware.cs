namespace app_homework.Middlewares
{
    public class CorrelationIdMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var correlationId = context.Request.Headers["CorrId"].FirstOrDefault();

            await next(context);
        }
    }
}