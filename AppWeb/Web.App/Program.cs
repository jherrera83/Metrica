﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Web.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.UseKestrel(o => { o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(1); })
                .Build();
    }
}