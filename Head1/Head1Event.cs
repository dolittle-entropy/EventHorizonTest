// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Dolittle.Events;

namespace Head1
{
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