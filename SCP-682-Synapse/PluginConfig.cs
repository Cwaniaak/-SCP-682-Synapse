using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synapse.Api;
using Synapse.Config;

namespace SCP_682_Synapse
{
    public class PluginConfig : AbstractConfigSection
    {
        public ushort Spawn_message_duration { get; set; } = 10;
        [Description("The text which gets displayed over the Player Name of Scp682")]
        public string DisplayName { get; set; } = "SCP-682";

        [Description("The Color which the text of Scp682 should have")]
        public string DisplayColor { get; set; } = "#C50000";
        public int spawn_chance { get; set; } = 100;
        [Description("is the SCP-682 supposed to kill with one bite")]
        public bool can_kill_on_oneshot { get; set; } = true;
        [Description("whether SCP-682 is to be able to Pry Gates?")]
        public bool can_PryGates { get; set; } = true;
        [Description("how much hp should SCP-682 get when he damage a human")]
        public int heal_hp_when_damage { get; set; } = 5;
        [Description("max hp")]
        public int MaxHP { get; set; } = 2200;
        [Description("every how many seconds SCP-682 health should regenerate?")]
        public int heal_time { get; set; } = 5;
        [Description("how much hp should be regenerated?")]
        public int heal_hp { get; set; } = 5;
        [Description("can scp 682 destroy doors?")]
        public bool can_destroy_door { get; set; } = true;
        [Description("how many % chance should SCP-682 have to destroy the door")]
        public int destroy_door_chance { get; set; } = 100;
    }
}
