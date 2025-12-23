namespace JHVehicle
{
    public class Config : Rocket.API.IRocketPluginConfiguration
    {
        public bool JustLastEffect;
        public bool StaminaBeforeHealth;
        public byte MinSpeed;
        public int InvertIfBelow;
        public System.Collections.Generic.List<Stance> Stances { get; set; }
        public System.Collections.Generic.List<Effect> Effects { get; set; }
        public System.Collections.Generic.List<EngineDmg> EngineDamageMultiplier { get; set; }
        public void LoadDefaults()
        {
            JustLastEffect = true;
            StaminaBeforeHealth = false;
            MinSpeed = 2;
            InvertIfBelow = -3;
            Stances = new System.Collections.Generic.List<Stance>() { new Stance(5, SDG.Unturned.EPlayerStance.CROUCH), new Stance(15, SDG.Unturned.EPlayerStance.PRONE) };
            Effects = new System.Collections.Generic.List<Effect>() { new Effect(8, false, true), new Effect(15, true, true), new Effect(70, true, true) };
            EngineDamageMultiplier = new System.Collections.Generic.List<EngineDmg>() { new EngineDmg { DmgMultiplier = 1.5f, Engine = SDG.Unturned.EEngine.CAR }, new EngineDmg { DmgMultiplier = 1.7f, Engine = SDG.Unturned.EEngine.TRAIN }, new EngineDmg { DmgMultiplier = 1f, Engine = SDG.Unturned.EEngine.BOAT }, new EngineDmg { DmgMultiplier = 0.6f, Engine = SDG.Unturned.EEngine.BLIMP }, new EngineDmg { DmgMultiplier = 0.5f, Engine = SDG.Unturned.EEngine.PLANE }, new EngineDmg { DmgMultiplier = 0.1f, Engine = SDG.Unturned.EEngine.HELICOPTER } };
        }
    }
}