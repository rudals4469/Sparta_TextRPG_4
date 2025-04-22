using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Monster : Animal
    {
        MonsterName MonsterName;
        List<Item> Items;
        public Monster()
        {
            MonsterName = MonsterName.MusurMom;
        }
    }
}
