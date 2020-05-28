// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Hosting.Microsoft;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Head1
{
    static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseDolittle()
                .ConfigureWebHostDefaults(_ =>
                {
                    _.UseStartup<Startup>();
                    _.UseUrls("http://*:5000");
                });
    }
}
