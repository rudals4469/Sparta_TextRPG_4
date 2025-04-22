using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Inventory
    {
        //public List<Item> Reward { get; set; }  // 퀘스트 아이템 보상
        public List<Weapon> Weapon { get; set; }
        public List<Armor> Armors { get; set; }
        public List<Shiled> Shild { get; set; }
        public List<Potion> Potions { get; set; }

        public void Add(Item item)
        {
        if (item.Type == ItemType.Weapon)
            {
                Weapon.Add(item);
            }
        if (item.Type == ItemType.Armor)
            {
                Armors.Add(item);
            }
        if (item.Type == ItemType.Shield)
            {
                Shild.Add(item);
            }
        if (item.Type == ItemType.Potion)
            {
                Potions.Add(item);
            }
        }
        
        

    }
}
