using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace JHVehicle.Commands
{
    public class CheckVehicle : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        public System.Collections.Generic.List<string> Permissions
        {
            get
            {
                return new System.Collections.Generic.List<string>() {
                    "jhvehicles.checkvehicle"
                };
            }
        }
        public string Name = "checkvehicle";
        public string Help => "Check your vehicles speed.";
        public string Syntax => "";
        public System.Collections.Generic.List<string> Aliases => new System.Collections.Generic.List<string> { "vehiclespeed", "vspeed", "checkvehiclespeed" };
        string IRocketCommand.Name => "checkvehicle";
        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer Player = (UnturnedPlayer)caller;
            if (Player.IsInVehicle)
            {
                InteractableVehicle vehicle = Player.CurrentVehicle;
                Rocket.Unturned.Chat.UnturnedChat.Say(Player, "Speed: " + vehicle.ReplicatedSpeed + ", " + vehicle.ReplicatedForwardVelocity + ", " + vehicle.AnimatedForwardVelocity + ", "+ Player.Player.movement.speed + " kph");
            }
        }
    }
}
