﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cobweb.Consul;
using Cobweb.Core.Common;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Cobweb.Consul.Configuration;

namespace Cobweb.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            //WebHost.CreateDefaultBuilder(args)
            //    .UseStartup<Startup>();

            var builder = new WebHostBuilder();
            builder
            .ConfigureAppConfiguration(b=> {
                b.AddJsonFile("appsettings.json");//add default settings
                b.AddConsul(consul => {
                    consul.Address = new Uri("http://localhost:8500");
                });
            })
            .ConfigureServices(services => {

            })
            .ConfigureLogging(log =>
            {
                log.ClearProviders();
                log.AddConsole();
                log.SetMinimumLevel(LogLevel.Trace);
                log.AddFilter((n, l)=>!n.StartsWith("Microsoft."));
            })
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseUrls($"http://localhost:{NetHelper.GetAvailablePort()}")
            .UseStartup<Startup>();
            
            return builder;
        }
    }
}
