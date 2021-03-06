// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using Dolittle.Events;
using Dolittle.Events.Filters;
using Dolittle.Events.Filters.EventHorizon;
using Dolittle.Logging;

namespace Head2.Feature1
{
    [Filter("cba00d22-3c04-4d42-a738-9d20de31f7cc")]
    public class PublicFilter : ICanFilterPublicEvents
    {
        readonly ILogger _logger;

        public PublicFilter(ILogger<PublicFilter> logger)
        {
            _logger = logger;
        }

        public Task<PublicFilterResult> Filter(IPublicEvent @event, EventContext eventContext)
        {
            return Task.FromResult(new PublicFilterResult(true, Guid.Empty));
        }
    }
}
