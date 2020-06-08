// Copyright (c) Dolittle. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using Dolittle.Commands.Coordination;
using Dolittle.Events;
using Dolittle.Events.Handling;
using Dolittle.Logging;

namespace Head1.Feature1
{

    [EventHandler("c59ee65c-bee1-459e-9689-7b4c9acae697")]
    public class Reaction : CommandExecutor, ICanHandleEvents
    {
        readonly ILogger _logger;

        public Reaction(
            ICommandContextManager commandContextManager,
            ICommandCoordinator commandCoordinator,
            ILogger logger) : base(commandContextManager, commandCoordinator)
        {
            _logger = logger;
        }

        public async Task Handle(MyPrivateEvent @event, EventContext eventContext)
        {
            _logger.Information($"Reacting to event : '{@event}'");
            // throw new System.Exception("DIE");
            var executeCommand = Task.Run(() =>
                {
                    try
                    {
                        var result = ExecuteCommand(new MyReactionCommand());
                        _logger.Information("Finished executing reaction command");
                        Console.WriteLine(result);
                    }
                    catch (Exception ex)
                    {
                        _logger.Warning(ex, "Error occurred while executing reaction command");
                    }
                });

            await executeCommand.ConfigureAwait(false);
        }
    }
}
