using Microsoft.IdentityModel.Tokens;

namespace app_homework.Middlewares
{
    public class LanguageMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var lang = context.Request.Headers["lang"].FirstOrDefault();

            if (!string.IsNullOrEmpty(lang) && (lang.ToLower().Equals("en") || lang.ToLower().Equals("ar")))
                await next(context);
            else
                return;   
        } 
    }
}
