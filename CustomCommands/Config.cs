using Synapse.Config;
using System.ComponentModel;

namespace CustomCommands
{
    public class Config : IConfigSection
    {
        [Description("Activate auto round lock the game when a player is in jail")]
        public bool RlockOnJail { get; set; } = false;

        [Description("Make the size of the player at 1 1 1 when he dies so he dosen't respawn and spin like a bayblade and die")]
        public bool ReScaleOnDeath { get; set; } = true;

        [Description("Activate the admin command that shows how many admins are connected")]
        public bool AdminCommand { get; set; } = true;
    }
}
