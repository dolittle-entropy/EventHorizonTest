// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Dolittle.Commands.Coordination;
using Dolittle.Events;
using Dolittle.Events.Handling;
using Dolittle.Events.Handling.EventHorizon;
using Dolittle.Logging;

namespace Head2
{
    [EventHandler("d3416616-d022-4133-a94b-d418fdc150b5"), Scope("6067a5fa-2151-4928-8ce2-90aa6cb9ca88")]
    public class MyExternalEventHandler : ICanHandleExternalEvents
    {
        readonly ICommandCoordinator _coordinator;
        readonly ILogger _logger;

        public MyExternalEventHandler(ICommandCoordinator coordinator, ILogger<MyExternalEventHandler> logger)
        {
            _coordinator = coordinator;
            _logger = logger;
        }

        public async Task Handle(Head1Event @event, EventContext eventContext)
        {
            _logger.Information($"Handling external event : '{@event}'");
            await Task.Delay(500).ConfigureAwait(false);
            _coordinator.Handle(new MyCommand());
        }
    }
}