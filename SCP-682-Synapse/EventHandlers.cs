using Synapse;
using Synapse.Api;
using System.Linq;
using Synapse.Api.Events.SynapseEventArguments;
using Interactables.Interobjects;
using UnityEngine;
using MEC;

namespace SCP_682_Synapse
{
    public class EventHandlers
    {
        public Scp682PlayerScript ps;
        public EventHandlers()
        {
            Server.Get.Events.Map.DoorInteractEvent += OnDoorInteract;
            Server.Get.Events.Player.PlayerSetClassEvent += OnSetClass;
            Server.Get.Events.Player.PlayerDamageEvent += OnDamage;
        }
        public void OnDoorInteract(DoorInteractEventArgs ev)
        {
            if(ev.Player.RoleID == 682)
                if (SCP682.Config.can_PryGates == true && ev.Door.VDoor is PryableDoor pryableDoor)
                {
                    pryableDoor.TryPryGate();
                }
            else if (SCP682.Config.scp682_can_destroy_door == true)
            {
                int d = Random.Range(0, 101);
                if (d <= SCP682.Config.scp682_destroy_door_chance && ev.Door.IsBreakable)
                {
                    ev.Door.TryBreakDoor();
                }
            }
        }

        public void OnSetClass(PlayerSetClassEventArgs ev)
        {
                if (ev.Role == RoleType.Scp93989)
                {
                    int s = Random.Range(0, 101);
                    if (s <= SCP682.Config.spawn_chance)
                    {
                       Timing.CallDelayed(0.1f, () =>
                       {
                          ev.Player.RoleID = 682;
                       });
                    }
                }
        }

        public void OnDamage(PlayerDamageEventArgs ev)
        {
            if (ev.Killer.RoleID == 682 && ev.Killer.Team != Team.SCP)
            {
                if (SCP682.Config.can_kill_on_oneshot == true)
                {
                    ev.Victim.Kill(DamageTypes.Scp939);
                }
                if (ev.Killer.Health < SCP682.Config.MaxHP)
                {
                    ev.Killer.Health = ev.Killer.Health + SCP682.Config.heal_hp_when_eat;
                }
            }
        }
    }
}
