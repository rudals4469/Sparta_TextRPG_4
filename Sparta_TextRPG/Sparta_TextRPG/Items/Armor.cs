using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Sparta_TextRPG
{
    internal class Armor : Item
    {
        public int ArmorPoint { get; set; }
        public bool IsEquipped { get; set; }
        public Armor(string name, string text, int price, ItemType type,int armorPoint) : base( name,  text,  price,  type)
        {
            this.ArmorPoint = armorPoint;
            this.IsEquipped = false;
        }
    }
}
