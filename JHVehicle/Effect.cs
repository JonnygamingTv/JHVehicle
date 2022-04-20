using System.Xml.Serialization;

namespace JHVehicle
{
    public class Effect
    {
        [XmlAttribute] public float Speed;
        [XmlAttribute] public bool BreakLegs;
        [XmlAttribute] public bool Bleed;

        public Effect() { }
        public Effect(float S, bool Legs = false, bool Blood = false) { Speed = S; BreakLegs = Legs; Bleed = Blood; }
    }
}
