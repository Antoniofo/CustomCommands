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
            IEnumerable<Player> admins = Server.Get.Players.Where(x => x.RemoteAdminAccess == true);
            result.State = CommandResultState.Ok;
            result.Message = $"Il y a {admins.Count()} admin connecté";
            return result;
        }
    }
}
