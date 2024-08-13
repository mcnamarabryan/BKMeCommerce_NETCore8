using System.Globalization;

namespace BKMeCommerceWeb.Middleware
{
    public class UserCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public UserCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userCulture = context.Request.Cookies["UserCulture"] ?? "en-US";

            var cultureInfo = new CultureInfo(userCulture);
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await _next(context);
        }
    }
}
