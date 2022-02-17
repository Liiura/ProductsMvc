using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ProductsStore.Extensions;
using ProductsStore.Presentation.SharedViewModels;
using System.Threading.Tasks;
namespace ProductsStore.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _Next;
        private const string _AdminConst = "Admin";
        private const string _ClientConst = "Client";
        public Middleware(RequestDelegate next)
        {
            _Next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var path = httpContext.Request.Path.Value;
            var splitPath = path.Split('/');
            if (splitPath[1] == _AdminConst || splitPath[1] == _ClientConst)
            {
                var currentSessionObject = httpContext.Session.GetObject<SessionModel>("UserSession");
                if (currentSessionObject == null)
                {
                    httpContext.Response.Redirect("/");
                }
                else
                {
                    if (splitPath[1] == _AdminConst && currentSessionObject.RoleType == _AdminConst)
                    {
                        if (!httpContext.Response.HasStarted)
                        {
                            await _Next.Invoke(httpContext);
                        }
                    }
                    else if (splitPath[1] == "Project" && currentSessionObject.RoleType == _ClientConst)
                    {
                        httpContext.Response.Redirect("/");
                    }
                }
            }
            if (!httpContext.Response.HasStarted)
            {
                await _Next.Invoke(httpContext);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
