// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;
using Dolittle.Commands;
using Dolittle.Commands.Coordination;

namespace Head1.Feature1
{
    public abstract class CommandExecutor
    {
        protected readonly ICommandContextManager CommandContextManager;
        protected readonly ICommandCoordinator CommandCoordinator;

        protected CommandExecutor(ICommandContextManager commandContextManager, ICommandCoordinator commandCoordinator)
        {
            CommandContextManager = commandContextManager;
            CommandCoordinator = commandCoordinator;
        }

        // needs to be public because of tests
        public CommandResult ExecuteCommand(ICommand command)
        {
            return CommandCoordinator.Handle(command);
        }
    }
}
