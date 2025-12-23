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
                    SDG.Unturned.EEngine eng = (SDG.Unturned.EEngine)System.Enum.Parse(typeof(SDG.Unturned.EEngine), command[0]);
                    if (!float.TryParse(command[0], out float multi))
                    {
                        Rocket.Unturned.Chat.UnturnedChat.Say(caller, "<engine> <multiplier, number>");
                        return;
                    }
                    JHVehicle.Instance.TypeDamage[eng] = multi;
                    EngineDmg gg = JHVehicle.Instance.Configuration.Instance.EngineDamageMultiplier.Find(g => g.Engine == eng);
                    if(gg == null) {
                        JHVehicle.Instance.Configuration.Instance.EngineDamageMultiplier.Add(new EngineDmg() { Engine = eng, DmgMultiplier = multi });
                    }
                    gg.DmgMultiplier=multi;
                    Rocket.Unturned.Chat.UnturnedChat.Say(caller, "Updated damage multiplier for "+eng+" to: " + multi);
                }
            }else
            {
                Rocket.Unturned.Chat.UnturnedChat.Say(caller, "<engine> <multiplier, number>. Currently: ");
                foreach(EngineDmg inp in JHVehicle.Instance.Configuration.Instance.EngineDamageMultiplier)
                {
                    Rocket.Unturned.Chat.UnturnedChat.Say(caller, inp.Engine.ToString() + ": " + inp.DmgMultiplier.ToString());
                }
            }
        }
    }
}
