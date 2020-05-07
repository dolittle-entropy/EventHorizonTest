// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Artifacts;
using Dolittle.Events;

namespace Head1.Feature1
{
    [Artifact("bc26f986-5515-4506-9944-cd7e93bec7fe")]
    public class Head1Event : IPublicEvent
    {
        public Head1Event(int myInteger, string myString)
        {
            MyInteger = myInteger;
            MyString = myString;
        }

        public int MyInteger { get; }

        public string MyString { get; }
    }
}