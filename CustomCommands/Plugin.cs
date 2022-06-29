using Synapse.Api.Plugin;
using Synapse.Api;
using Synapse.Config;
using Synapse;
using Synapse.Api.Events.SynapseEventArguments;
using System.Linq;

namespace CustomCommands
{
    [PluginInformation(
        Name = "CustomCommands",
        Author = "Antoniofo",
        Description = "Adds some commands",
        LoadPriority = 0,
        SynapseMajor = SynapseController.SynapseMajor,
        SynapseMinor = SynapseController.SynapseMinor,
        SynapsePatch = SynapseController.SynapsePatch,
        Version = "v1.1.1"

        )]
    public class Plugin : AbstractPlugin
    {

        [Synapse.Api.Plugin.Config(section = "CustomCommands")]
        public static Config Config { get; set; }

        
        public override void Load()
        {
            base.Load();
            Server.Get.Events.Player.PlayerDeathEvent += OnDeath;
            Server.Get.Events.Player.PlayerLeaveEvent += OnLeave;
        }

        private void OnLeave(PlayerLeaveEventArgs ev)
        {            
            
            if (ev.Player.Jail.IsJailed)
            {
                if (Server.Get.Players.Where(x => x.Jail.IsJailed == true).Count() == 1)
                {                    
                    if (Config.RlockOnJail)
                    {
                        Map.Get.Round.RoundLock = false;
                    }
                }
                if (!ev.Player.RemoteAdminAccess)
                {
                    ev.Player.Ban(Config.BanDuration, "Disconnect in Admin Tower");
                }                
            }
        }

        private void OnDeath(PlayerDeathEventArgs ev)
        {
            ev.Victim.Scale = new UnityEngine.Vector3(1,1,1);
        }

        public override void ReloadConfigs()
        {
            base.ReloadConfigs();
        }
    }
}
