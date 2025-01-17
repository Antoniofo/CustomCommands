﻿using Synapse.Command;

namespace CustomCommands.Commands
{

    [CommandInformation(
        Name = "cisound",
        Aliases = new string[] { "playci" },
        Description = "Play the sound when chaos spawn but don't spawn chaos",
        Permission = "cc.sound",
        Platforms = new[] { Platform.RemoteAdmin },
        Usage = "Type cisound or playci to play the sound"
        )]

    public class CiSound : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();

            SynapseController.Server.Map.Round.PlayChaosSpawnSound();
            result.State = CommandResultState.Ok;
            result.Message = "Sound played for D-boii";
            return result;
        }
    }
}
