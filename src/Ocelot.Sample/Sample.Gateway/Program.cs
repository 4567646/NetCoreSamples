﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Sample.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((contex, builder) =>
                {
                    //builder.SetBasePath(contex.HostingEnvironment.ContentRootPath).AddJsonFile("Ocelot.json");
                    //builder.SetBasePath(contex.HostingEnvironment.ContentRootPath).AddJsonFile("Ocelot.json");
                    builder.AddJsonFile($"appsettings.{contex.HostingEnvironment.EnvironmentName}.json", optional: true);
                })
            .UseStartup<Startup>();
    }
}
