﻿// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Dolittle.Artifacts;
using Dolittle.Booting;
using Dolittle.Commands.Coordination;
using Dolittle.DependencyInversion;
using Dolittle.Execution;
using Dolittle.Hosting.Microsoft;
using Dolittle.Tenancy;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Head3.Feature1
{
    static class Program
    {
        static async Task Main()
        {
            var hostBuilder = new HostBuilder();
            hostBuilder.ConfigureLogging(_ => _.AddConsole());
            hostBuilder.UseDolittle();
            hostBuilder.UseEnvironment("Development");
            var host = hostBuilder.Build();

            var container = host.Services.GetService(typeof(IContainer)) as IContainer;

            var executionContextManager = container.Get<IExecutionContextManager>();

            executionContextManager.CurrentFor(TenantId.Development);

            await host.RunAsync().ConfigureAwait(false);
        }
    }
}
