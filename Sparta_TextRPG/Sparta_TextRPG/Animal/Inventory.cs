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

        // count : 전체의 수를 알려주는 int 리턴



        //숫자가 들어오면 
        // 예를들면 다 4개
        // 10
        //무기 4개 방어구 4 실드에 2번째걸 리턴 item

    }
}
