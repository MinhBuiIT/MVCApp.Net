using Microsoft.AspNetCore.Builder;
using System.Net;

namespace MVCApp.MyExtension
{
    public static class AddStatusCode
    {
        public static void AddStatusCodePage(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(errApp =>
            {
                errApp.Run(async context =>
                {
                    var response = context.Response;
                    var code = response.StatusCode;

                    var content = @$"
        <!DOCTYPE html>
        <html lang=""en"">
            <head>
                <meta charset=""utf-8""/>
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
                <title>{(HttpStatusCode)code}</title>
                
            </head>
            <body>
                <h2>{code} - {(HttpStatusCode)code}</h2>
            </body>
        </html>";
                    response.Headers.Add("Content-Type", "text/html");
                    await response.WriteAsync(content);
                });
            });
        }
    }
}
