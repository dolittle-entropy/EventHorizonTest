// Copyright (c) Dolittle. All rights reserved.
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

namespace Head3
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
            var artifactTypeMap = container.Get<IArtifactTypeMap>();
            artifactTypeMap.Register(new Artifact(Guid.Parse("a4eed54e-2449-4164-a36e-8df80dcf8053"), 1), typeof(Head2Event));
            artifactTypeMap.Register(new Artifact(Guid.Parse("bc26f986-5515-4506-9944-cd7e93bec7fe"), 1), typeof(Head1Event));

            executionContextManager.CurrentFor(TenantId.Development);

            await host.RunAsync().ConfigureAwait(false);
        }
    }
}
