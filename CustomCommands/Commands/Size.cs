using Synapse;
using Synapse.Api;
using Synapse.Command;
using UnityEngine;

namespace CustomCommands.Commands
{

    [CommandInformation(
        Name = "size",
        Aliases = new string[] { },
        Description = "change the size of a player",
        Permission = "cc.size",
        Platforms = new[] { Platform.RemoteAdmin },
        Usage = "size x y z"
        )]

    public class Size : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();
            if (context.Arguments.Count == 4)
            {
                var parg = context.Arguments.Array[1];
                var xarg = context.Arguments.Array[2];
                var yarg = context.Arguments.Array[3];
                var zarg = context.Arguments.Array[4];

                if (float.TryParse(xarg, out var x) && float.TryParse(yarg, out var y) && float.TryParse(zarg, out var z))
                {
                    if (Server.Get.TryGetPlayers(parg, out var palyers, context.Player))
                    {
                        foreach (Player players in palyers)
                            players.Scale = new Vector3(x, y, z);
                        
                        result.Message = "Size changed";
                        result.State = CommandResultState.Ok;

                    }
                    else
                    {
                        result.Message = "player unknown";
                        result.State = CommandResultState.Error;

                    }
                }
                else
                {
                    result.Message = "Unusable parameter";
                    result.State = CommandResultState.Error;
                }
            }
            else
            {
                result.State = CommandResultState.Error;
                result.Message = "Not the good amount of argument";
            }

            return result;
        }
    }
}
