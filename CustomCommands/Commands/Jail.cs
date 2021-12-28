using Synapse.Api;
using Synapse.Command;

namespace CustomCommands.Commands
{

    [CommandInformation(
        Name = "jail",
        Aliases = new string[] { },
        Description = "Jail/unjail a player",
        Permission = "twin.jail",
        Platforms = new[] { Platform.RemoteAdmin },
        Usage = "Type jail to jail a player"
        )]

    public class Jail : ISynapseCommand
    {
        public CommandResult Execute(CommandContext context)
        {

            var result = new CommandResult();


            if (context.Arguments.Count == 1)
            {
                string arg = context.Arguments.Array[1];
                foreach (Player players in SynapseController.Server.Players)
                {

                    if (players.NickName.ToLower().Contains(arg.ToLower()))
                    {
                        if (players.Jail.IsJailed)
                        {
                            players.Jail.UnJailPlayer();
                            if (Plugin.Config.RlockOnJail)
                            {
                                SynapseController.Server.Map.Round.RoundLock = false;
                            }
                            result.Message = "Le joueur a été unjail";
                            result.State = CommandResultState.Ok;
                            break;
                        }
                        else
                        {
                            if (Plugin.Config.RlockOnJail)
                            {
                                SynapseController.Server.Map.Round.RoundLock = true;
                            }
                            players.Jail.JailPlayer(context.Player);
                            result.Message = "Le joueur a été jail";
                            result.State = CommandResultState.Ok;
                            break;
                        }

                    }
                    else if (players.PlayerId.ToString() == arg)
                    {

                        if (players.Jail.IsJailed)
                        {

                            players.Jail.UnJailPlayer();
                            if (Plugin.Config.RlockOnJail)
                            {
                                SynapseController.Server.Map.Round.RoundLock = false;
                            }
                            result.Message = "Le joueur a été unjail";
                            result.State = CommandResultState.Ok;
                            break;
                        }
                        else
                        {
                            if (Plugin.Config.RlockOnJail)
                            {
                                SynapseController.Server.Map.Round.RoundLock = true;
                            }
                            players.Jail.JailPlayer(context.Player);
                            result.Message = "Le joueur a été jail";
                            result.State = CommandResultState.Ok;
                            break;
                        }

                    }
                    else
                    {
                        result.State = CommandResultState.Error;
                        result.Message = "Le joueur n'a pas été trouvé";
                    }

                }
                if (result.State != CommandResultState.Ok)
                {
                    result.State = CommandResultState.Error;
                    result.Message = "Le joueur n'a pas été trouvé";
                }

            }
            else
            {
                result.State = CommandResultState.Error;
                result.Message = "Vous devez mettre le nom ou l'id d'un joueur en argument";
            }

            return result;
        }
    }
}
