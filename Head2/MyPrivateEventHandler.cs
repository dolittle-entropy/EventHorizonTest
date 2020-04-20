// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Dolittle.Events;
using Dolittle.Events.Handling;
using Dolittle.Logging;

namespace Head2
{
    [EventHandler("38eeb77f-90ca-405c-a733-3b0e6f0b0ef3")]
    public class MyPrivateEventHandler : ICanHandleEvents
    {
        readonly ILogger _logger;

        public MyPrivateEventHandler(ILogger<MyPrivateEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(MyPrivateEvent @event, EventContext eventContext)
        {
            _logger.Information($"Handling event : '{@event}'");
            // throw new System.Exception("DIE");
            return Task.CompletedTask;
        }
    }
}
