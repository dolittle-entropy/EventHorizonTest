// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using Dolittle.Events;
using Dolittle.Events.Filters;
using Dolittle.Events.Filters.EventHorizon;
using Dolittle.Logging;

namespace Head1.Feature1
{
    [Filter("db7acf1e-a640-41f3-934f-f2f188e1b1e9")]
    public class PublicFilter : ICanFilterPublicEvents
    {
        readonly ILogger _logger;

        public PublicFilter(ILogger<PublicFilter> logger)
        {
            _logger = logger;
        }

        public Task<PublicFilterResult> Filter(IPublicEvent @event, EventContext context)
        {
            return Task.FromResult(new PublicFilterResult(true, Guid.Empty));
        }
    }
}
