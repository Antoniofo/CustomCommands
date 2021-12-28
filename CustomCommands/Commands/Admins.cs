using Synapse.Command;
using System.Linq;
using Synapse;
using Synapse.Api;
using System.Collections.Generic;

namespace CustomCommands.Commands
{

    [CommandInformation(
        Name = "admins",
        Aliases = new string[] { "ads" },
        Description = "Show the number of connected admins",
        Permission = "",
        Platforms = new[] { Platform.RemoteAdmin, Platform.ServerConsole, Platform.ClientConsole },
        Usage = "admins or ads"
        )]

    public class Admins : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();
            if (Plugin.Config.AdminCommand)
            {
                IEnumerable<Player> admins = Server.Get.Players.Where(x => x.RemoteAdminAccess == true);
                result.Message = $"{admins.Count()} connected admin";
                result.State = CommandResultState.Ok;
            }
            else
            {
                result.State = CommandResultState.Error;
                result.Message = "Command not activated";
            }            
            return result;
        }
    }
}
