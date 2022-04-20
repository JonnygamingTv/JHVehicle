using Rocket.API;
using Rocket.Unturned.Player;

namespace JHVehicle.Commands
{
    public class DmgMultiplier : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;
        public System.Collections.Generic.List<string> Permissions
        {
            get
            {
                return new System.Collections.Generic.List<string>() {
                    "jhvehicles.multiplier"
                };
            }
        }
        public string Name = "dmgmultiplier";
        public string Help => "Change the multiplier for damage from vehicles speeds.";
        public string Syntax => "";
        public System.Collections.Generic.List<string> Aliases => new System.Collections.Generic.List<string> { "vehicledamagemultiplier", "vehicledmgmultiplier", "vdmg", "vdm" };
        string IRocketCommand.Name => "dmgmultiplier";
        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (command.Length != 0)
            {
                if (command[0] == "save")
                {
                    JHVehicle.Instance.Configuration.Save();
                    Rocket.Unturned.Chat.UnturnedChat.Say(caller, "Saved!");
                }
                else
                {
                    float.TryParse(command[0], out JHVehicle.Instance.Configuration.Instance.Multiplier);
                    Rocket.Unturned.Chat.UnturnedChat.Say(caller, "Updated damage multiplier to: " + JHVehicle.Instance.Configuration.Instance.Multiplier);
                }
            }else
            {
                Rocket.Unturned.Chat.UnturnedChat.Say(caller, "<multiplier, number>, currently: "+ JHVehicle.Instance.Configuration.Instance.Multiplier);
            }
        }
    }
}
