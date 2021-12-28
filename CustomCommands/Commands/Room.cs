using Synapse.Api;
using Synapse.Command;
using System.Linq;
using UnityEngine;

namespace CustomCommands.Commands
{

    [CommandInformation(
        Name = "room",
        Aliases = new string[] { },
        Description = "Change color of all room",
        Permission = "twin.room",
        Platforms = new[] { Platform.RemoteAdmin },
        Usage = "Type room"
        )]

    public class RoomIntensity : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();
            float arg = float.Parse(context.Arguments.Array[1]);
            float arg2 = float.Parse(context.Arguments.Array[2]);
            float arg3 = float.Parse(context.Arguments.Array[3]);
            if (context.Arguments.Count == 3)
            {
                foreach (Room room in SynapseController.Server.Map.Rooms)
                {
                    room.LightController.WarheadLightColor = new Color(arg / (byte.MaxValue), arg2 / (byte.MaxValue), arg3 / (byte.MaxValue));
                    room.LightController.WarheadLightOverride = true;

                }
                result.Message = "Les lumières ont été changer";
                result.State = CommandResultState.Ok;
            }
            else
            {
                foreach (Room room in SynapseController.Server.Map.Rooms)
                {
                    room.LightController.WarheadLightOverride = false;
                    room.LightController.WarheadLightColor = new Color(255 / (byte.MaxValue), 0 / (byte.MaxValue), 0 / (byte.MaxValue));
                }
                result.Message = "Les lumières ont été reset";
                result.State = CommandResultState.Ok;
            }
            return result;
        }
    }
}
