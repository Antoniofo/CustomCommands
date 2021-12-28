using Synapse.Api.Plugin;
using Synapse.Api;
using Synapse.Config;
using Synapse;
using Synapse.Api.Events.SynapseEventArguments;
using System;

namespace CustomCommands
{
    [PluginInformation(
        Name = "CustomCommands",
        Author = "Antonio",
        Description = "Adds some commands",
        LoadPriority = 0,
        SynapseMajor = 2,
        SynapseMinor = 8,
        SynapsePatch = 0,
        Version = "v1.1.0"

        )]
    public class Plugin : AbstractPlugin
    {

        [Synapse.Api.Plugin.Config(section = "CustomCommands")]
        public static Config Config { get; set; }

        
        public override void Load()
        {
            base.Load();
            Server.Get.Events.Player.PlayerDeathEvent += OnDeath;
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
