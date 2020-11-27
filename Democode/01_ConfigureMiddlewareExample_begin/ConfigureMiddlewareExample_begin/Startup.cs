﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureMiddlewareExample_begin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("This text was generated by the app.Run middleware.");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync($"This text was generated by the app.Use middleware. Request path is: {context.Request.Path.Value}<br />");
                await next.Invoke();
            });
        }
    }
}
