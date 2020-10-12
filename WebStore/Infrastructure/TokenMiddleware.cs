using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Infrastructure
{
    public class TokenMiddleware
    {
        private const string correctToken = "qwerty123";

        public RequestDelegate Next { get; }

        public TokenMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["referenceToken"];

            // если нет токена, то ничего не делаем, передаем запрос дальше по конвейеру
            if (string.IsNullOrEmpty(token))
            {
                await Next.Invoke(context);
                return;
            }
            if (token == correctToken)
            {
                // обрабатываем токен...
                await Next.Invoke(context);
            }
            else
            {
                await context.Response.WriteAsync("Token is incorrect");
            }
        }
    }
}
