// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Events;

namespace Head2.Feature1
{
    public class MyPrivateEvent : IEvent
    {
        public MyPrivateEvent(string stuff)
        {
            Stuff = stuff;
        }

        public string Stuff { get; }
    }
}