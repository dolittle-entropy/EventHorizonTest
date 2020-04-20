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

namespace Head2
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

            var commandContextManager = container.Get<ICommandContextManager>();
            var executionContextManager = container.Get<IExecutionContextManager>();
            var commandCoordinator = container.Get<ICommandCoordinator>();
            var artifactTypeMap = container.Get<IArtifactTypeMap>();
            artifactTypeMap.Register(new Artifact(Guid.Parse("7bda4646-4f21-4538-8b5e-ae4d71b4005f"), 1), typeof(MyAggregate));
            artifactTypeMap.Register(new Artifact(Guid.Parse("a4eed54e-2449-4164-a36e-8df80dcf8053"), 1), typeof(Head2Event));
            artifactTypeMap.Register(new Artifact(Guid.Parse("2626352e-41d2-4d40-b3dd-e8efdee9bcac"), 1), typeof(MyPrivateEvent));
            artifactTypeMap.Register(new Artifact(Guid.Parse("bc26f986-5515-4506-9944-cd7e93bec7fe"), 1), typeof(Head1Event));
            artifactTypeMap.Register(new Artifact(Guid.Parse("522c007d-9498-4aa2-a9ee-f43e8d5aec2a"), 1), typeof(MyCommand));

            executionContextManager.CurrentFor(TenantId.Development);

            var commandResult = commandCoordinator.Handle(new MyCommand());

            await host.RunAsync().ConfigureAwait(false);
        }
    }
}
