using SDG.Unturned;
using System.Collections.Generic;
using UnityEngine;

namespace JHVehicle
{
    public class JHVehicle : Rocket.Core.Plugins.RocketPlugin<Config>
    {
        public static JHVehicle Instance { get; private set; }
        protected override void Load()
        {
            Instance = this;
            Rocket.Core.Logging.Logger.Log("Support: JonHosting.com");
            VehicleManager.onExitVehicleRequested += ExitVehicleRequestHandler;
            Rocket.Core.Logging.Logger.Log("Loaded!");
        }
        protected override void Unload()
        {
            Instance = null;
            VehicleManager.onExitVehicleRequested -= ExitVehicleRequestHandler;
            Rocket.Core.Logging.Logger.Log("Unloaded!");
        }

        public void ExitVehicleRequestHandler(Player player, InteractableVehicle vehicle, ref bool shouldAllow, ref Vector3 pendingLocation, ref float pendingYaw)
        {
            if (vehicle.speed > Configuration.Instance.MinSpeed)
            {
                Rocket.Unturned.Player.UnturnedPlayer P = Rocket.Unturned.Player.UnturnedPlayer.FromPlayer(player);
#if DEBUG
            Rocket.Unturned.Chat.UnturnedChat.Say(P, "Speed: "+vehicle.speed+", "+vehicle.physicsSpeed+", "+vehicle.spedometer+" kph");
#endif
                bool SF = false;
                byte TS = 0;
                for (byte i = 0; i < Configuration.Instance.Stances.Count; i++)
#if DEBUG
            {
                Rocket.Unturned.Chat.UnturnedChat.Say(P, vehicle.speed+" > "+Configuration.Instance.Stances[i].Speed + " | " + (vehicle.speed > Configuration.Instance.Stances[i].Speed));

#endif
                    if (vehicle.speed > Configuration.Instance.Stances[i].Speed && (!SF || Configuration.Instance.Stances[i].Speed > Configuration.Instance.Stances[TS].Speed)) { SF = true; TS = i; }
#if DEBUG
            }
#endif
                if (SF)
                {
#if DEBUG
                    Rocket.Unturned.Chat.UnturnedChat.Say(P, "Stance "+ Configuration.Instance.Stances[TS].StanceName + " was found and is being set.");
#endif
                    SF = false;
                    player.stance.stance = Configuration.Instance.Stances[TS].StanceName;
                    player.stance.checkStance(Configuration.Instance.Stances[TS].StanceName);
                    StartCoroutine(nameof(UpdateStance), new object[2] { P, TS });
                }
                if (Configuration.Instance.JustLastEffect)
                {
                    for (byte i = 0; i < Configuration.Instance.Effects.Count; i++) if (vehicle.speed > Configuration.Instance.Effects[i].Speed && (!SF || Configuration.Instance.Effects[i].Speed > Configuration.Instance.Effects[TS].Speed)) { SF = true; TS = i; }
                    if (SF)
                    {
#if DEBUG
                    Rocket.Unturned.Chat.UnturnedChat.Say(P, "Checking.. " + Configuration.Instance.Effects[TS].BreakLegs + " | " + Configuration.Instance.Effects[TS].Bleed);
#endif
                        if (Configuration.Instance.Effects[TS].BreakLegs)
#if DEBUG
                    {
#endif
                            player.life.breakLegs();
#if DEBUG
                        Rocket.Unturned.Chat.UnturnedChat.Say(P, "Break legs.");
                    }
#endif
                        if (Configuration.Instance.Effects[TS].Bleed) P.Bleeding = true;
                    }
                }
                else
                {
                    bool broke = false;
                    bool bleed = false;
                    for (byte i = 0; i < Configuration.Instance.Effects.Count; i++) if (vehicle.speed > Configuration.Instance.Effects[i].Speed) { if (Configuration.Instance.Effects[i].Bleed) bleed = true; if (Configuration.Instance.Effects[i].BreakLegs) broke = true; }
                    if (broke) player.life.breakLegs();
                    if (bleed) P.Bleeding = true;
                }
                float dmg = vehicle.speed * Configuration.Instance.Multiplier;
                if (Configuration.Instance.StaminaBeforeHealth)
                {
                    float dmga = P.Stamina - dmg;
                    if (dmga > 0) player.life.serverModifyStamina(-dmg); else player.life.serverModifyStamina(dmga);

                    dmg -= P.Stamina;
                }
                if (dmg > 0) player.life.serverModifyHealth(-dmg);
            }
        }
        private System.Collections.IEnumerator UpdateStance(object[] parms)
        {
            Rocket.Unturned.Player.UnturnedPlayer victim = (Rocket.Unturned.Player.UnturnedPlayer)parms[0];
            byte TS = (byte)parms[1];
            yield return new WaitForSeconds((victim.Ping > 10 ? victim.Ping/1000 : 0.1f));

            victim.Player.stance.stance = Configuration.Instance.Stances[TS].StanceName;
            victim.Player.stance.checkStance(Configuration.Instance.Stances[TS].StanceName);
        }
    }
}
