using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Potion : Item
    {
        public int HealPoint { get; set; }
        public int Count {  get; set; }

        public PotionType PotionType { get; set; }
        public Potion(string name, string text, int price, ItemType type, int HealPoint) : base(name, text, price, type)
        {
            this.HealPoint = HealPoint;
            Count = 0;
        }
    }
}
