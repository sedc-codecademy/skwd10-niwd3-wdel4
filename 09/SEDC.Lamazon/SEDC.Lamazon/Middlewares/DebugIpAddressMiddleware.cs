using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DebugIpAddressMiddleware
    {
        private readonly RequestDelegate _next;

        public DebugIpAddressMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Connection.RemoteIpAddress = GetPublicIPAddress();
            return _next(httpContext);
        }

        private static IPAddress GetPublicIPAddress()
        {
            string responseData;
            string address;

            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using(WebResponse response = request.GetResponse())
            using(StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                responseData = stream.ReadToEnd();
            }

            int first = responseData.IndexOf("Address: ") + 9;
            int last = responseData.LastIndexOf("</body>");

            address = responseData.Substring(first, last - first);

            return IPAddress.Parse(address);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DebugIpAddressMiddlewareExtensions
    {
        public static IApplicationBuilder UseDebugIpAddressMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DebugIpAddressMiddleware>();
        }
    }
}
