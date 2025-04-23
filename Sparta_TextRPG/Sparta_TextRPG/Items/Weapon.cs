using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Weapon : Item
    {
        public int AttackPoint { get; set; }
        public bool IsEquipped { get; set; }

        public Weapon(string name, string text, int price, ItemType type, int attackPoint) : base(name, text, price, type)
        {
            this.AttackPoint = attackPoint;
            this.IsEquipped = false;
        }
    }
}
