﻿using System;
using System.Collections.Generic;
using log4net;
using Monzo.Framework.Services;

namespace Monzo.Client
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var log = LogManager.GetLogger(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            var configService = new ConfigurationService();
            var logger = new Logger(log);

            var httpService = new HttpService(logger);

            var headers = new Dictionary<string, string>()
            {
                {
                    "Authorization",
                    "Bearer " + configService.GetEnvironmentVariable("MONZO")
                }
            };

            Console.WriteLine("Hello World! 1");
            var result = httpService.Get(new Uri("https://api.monzo.com/ping/whoami"), headers);

            Console.WriteLine("Hello World! 2");
            result.Wait();
            Console.WriteLine("Hello World! 3 ");
            Console.WriteLine(result.Result);

            Console.WriteLine("Hello World! 4");
            Console.ReadLine();
        }
    }
}