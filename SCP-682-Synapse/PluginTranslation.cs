using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synapse.Translation;

namespace SCP_682_Synapse
{
    public class PluginTranslation : IPluginTranslation
    {
        public string spawn_message { get; private set; } = "<b>You are <color=red>SCP-682</color></b>";
    }
}
