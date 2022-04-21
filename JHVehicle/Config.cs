namespace JHVehicle
{
    public class Config : Rocket.API.IRocketPluginConfiguration
    {
        public bool JustLastEffect;
        public bool StaminaBeforeHealth;
        public byte MinSpeed;
        public System.Int16 InvertIfBelow;
        public float Multiplier;
        public System.Collections.Generic.List<Stance> Stances { get; set; }
        public System.Collections.Generic.List<Effect> Effects { get; set; }
        public void LoadDefaults()
        {
            JustLastEffect = true;
            StaminaBeforeHealth = false;
            MinSpeed = 2;
            InvertIfBelow = -3;
            Multiplier = 1.5f;
            Stances = new System.Collections.Generic.List<Stance>() { new Stance(5, SDG.Unturned.EPlayerStance.CROUCH), new Stance(15, SDG.Unturned.EPlayerStance.PRONE) };
            Effects = new System.Collections.Generic.List<Effect>() { new Effect(8, false, true), new Effect(15, true, true), new Effect(70, true, true) };
        }
    }
}