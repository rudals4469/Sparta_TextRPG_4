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
        public List<Potion> Potions { get; set; } // 0 hp  , 1 mp

        public Item GetItemByIndex(int index)
        {
            if (index < Weapon.Count)
                return Weapon[index];
            index -= Weapon.Count;

            if (index < Armors.Count)
                return Armors[index];
            index -= Armors.Count;

            if (index < Shild.Count)
                return Shild[index];
            index -= Shild.Count;

            if (index < Potions.Count)
                return Potions[index];

            return null;
        }
        public void Remove(Item item)
        {
            if (item.Type == ItemType.Weapon)
                Weapon.Remove((Weapon)item);
            else if (item.Type == ItemType.Armor)
                Armors.Remove((Armor)item);
            else if (item.Type == ItemType.Shield)
                Shild.Remove((Shiled)item);
            else if (item.Type == ItemType.Potion)
                Potions.Remove((Potion)item);
        }


        public void Add(Item item)
        {
        if (item.Type == ItemType.Weapon)
            {
                Weapon.Add((Weapon)item);
            }
        if (item.Type == ItemType.Armor)
            {
                Armors.Add((Armor)item);
            }
        if (item.Type == ItemType.Shield)
            {
                Shild.Add((Shiled)item);
            }
        if (item.Type == ItemType.Potion)
            {
                Potions.Add((Potion)item);
            }
        }

       

    }
}
