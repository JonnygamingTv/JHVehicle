using System.Xml.Serialization;

namespace JHVehicle
{
    public class Stance
    {
        [XmlAttribute] public float Speed;
        [XmlAttribute] public SDG.Unturned.EPlayerStance StanceName;
        public Stance() { }
        public Stance(float p, SDG.Unturned.EPlayerStance n) { Speed = p; StanceName = n; }
    }
}
