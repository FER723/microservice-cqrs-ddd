﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using ServicioPrueba.API;

namespace ServicioPrueba.FunctionalTests
{
    public class ServicioPruebaTestsStartup : Startup
    {
        public ServicioPruebaTestsStartup(IConfiguration env) : base(env)
        {
        }

        //protected override void ConfigureAuth(IApplicationBuilder app)
        //{
        //    if (Configuration["isTest"] == bool.TrueString.ToLowerInvariant())
        //    {
        //        app.UseMiddleware<AutoAuthorizeMiddleware>();
        //    }
        //    else
        //    {
        //        base.ConfigureAuth(app);
        //    }
        //}
    }
}
