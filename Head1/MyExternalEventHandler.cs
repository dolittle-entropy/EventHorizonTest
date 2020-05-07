// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Dolittle.Commands.Coordination;
using Dolittle.Events;
using Dolittle.Events.Handling;
using Dolittle.Events.Handling.EventHorizon;
using Dolittle.Logging;

namespace Head1.Feature1
{
    [EventHandler("93d43c62-cfc0-469d-973f-8f05781e4718"), Scope("a1ddc2b3-45e3-4161-bbef-3dcb3d212337")]
    public class MyExternalEventHandler : ICanHandleExternalEvents
    {
        readonly ICommandCoordinator _coordinator;
        readonly ILogger _logger;

        public MyExternalEventHandler(ICommandCoordinator coordinator, ILogger<MyExternalEventHandler> logger)
        {
            _coordinator = coordinator;
            _logger = logger;
        }

        public async Task Handle(Head2Event @event, EventContext eventContext)
        {
            _logger.Information($"Handling external event : '{@event}'");
            await Task.Delay(500).ConfigureAwait(false);
            _coordinator.Handle(new MyCommand());
        }
    }
}