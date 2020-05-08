// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Dolittle.Commands.Coordination;
using Dolittle.Events;
using Dolittle.Events.Handling;
using Dolittle.Events.Handling.EventHorizon;
using Dolittle.Logging;

namespace Head3.Feature1
{
    [EventHandler("d7704bb1-eb8c-4fa8-b71f-b6d7c342c8f0"), Scope("28cd2d41-7794-42a4-a919-b4f83bd79189")]
    public class MyExternalEventHandler : ICanHandleExternalEvents
    {
        readonly ILogger _logger;

        public MyExternalEventHandler(ILogger<MyExternalEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(Head1Event @event, EventContext eventContext)
        {
            _logger.Information($"Handling external event : '{@event}'");
            await Task.Delay(500).ConfigureAwait(false);
        }

        public async Task Handle(Head2Event @event, EventContext eventContext)
        {
            _logger.Information($"Handling external event : '{@event}'");
            await Task.Delay(500).ConfigureAwait(false);
        }
    }
}