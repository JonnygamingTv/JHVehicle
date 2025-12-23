using System.Xml.Serialization;

namespace JHVehicle
{
    public class EngineDmg
    {
        [XmlText]
        public float DmgMultiplier { get; set; }
        [XmlAttribute]
        public SDG.Unturned.EEngine Engine;
        public EngineDmg() { }
    }
}
