using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Shield : Item
    {
        public int AttackPoint { get; set; }
        public int ArmorPoint { get; set; }
        public bool IsEquipped { get; set; }

        public Shield(string name, string text, int price, ItemType type, int attackPoint, int armorPoint) : base(name, text, price, type)
        {
            this.AttackPoint = attackPoint;
            this.ArmorPoint = armorPoint;
            this.IsEquipped = false;
        }

    }
}
