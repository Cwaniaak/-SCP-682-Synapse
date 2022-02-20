using MEC;
using Synapse.Api;
using System.Collections.Generic;
using UnityEngine;

namespace SCP_682_Synapse
{
    public class Scp682PlayerScript : Synapse.Api.Roles.Role
    {
        public System.Random rnd = new System.Random();

        public List<CoroutineHandle> coroutines = new List<CoroutineHandle>();
        public override int GetRoleID() => 682;

        public override string GetRoleName() => "SCP-682";

        public override int GetTeamID() => (int)Team.SCP;


        public override void Spawn()
        {
            if (Player.RoleType != RoleType.Scp93989)
            {
                Player.RoleType = RoleType.Scp93989;
            }
            Player.Health = SCP682.Config.MaxHP;
            Player.SendBroadcast(SCP682.Config.Spawn_message_duration, SCP682.PluginTranslation.ActiveTranslation.spawn_message);
            Player.Scale = new Vector3(1.22f, 1, 1.22f);
            Player.DisplayInfo = $"<color={SCP682.Config.DisplayColor}>{SCP682.Config.DisplayName}</color>";
            coroutines.Add(Timing.RunCoroutine(Heal()));
        }

        public override void DeSpawn()
        {
            Map.Get.AnnounceScpDeath("6 8 2");
            Player.DisplayInfo = "";
            Player.Scale = new Vector3(1, 1, 1);
            foreach (CoroutineHandle coroutine in coroutines)
            {
                Timing.KillCoroutines(coroutine);
            }
            coroutines.Clear();
        }

        public IEnumerator<float> Heal()
        {
            for (; ; )
            {
                Player.Heal(SCP682.Config.heal_hp);
                yield return Timing.WaitForSeconds(SCP682.Config.heal_time);
            }
        }
    }
}
