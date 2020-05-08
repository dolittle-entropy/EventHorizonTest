// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Artifacts;
using Dolittle.Events;

namespace Head2.Feature1
{
    public class Head2Event : IPublicEvent
    {
        public Head2Event(string something)
        {
            Something = something;
        }

        public string Something { get; }
    }
}