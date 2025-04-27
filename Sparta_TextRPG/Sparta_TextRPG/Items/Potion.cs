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
        public int Count {  get; set; } // 갯수를 상정하고 만들었습니다.
        public PotionType PotionType { get; set; }
        public Potion(string name, string text, int price, PotionType PotionType, int HealPoint, ItemType type)
            : base(name, text, price, type)
        {
            this.PotionType = PotionType;
            this.HealPoint = HealPoint;
            Count = 0;
        }
    }
}
