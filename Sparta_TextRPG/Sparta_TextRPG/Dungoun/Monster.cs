using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            
        }
        public void MonsterCreate()
        {
            Random rand = new Random();
            int SpawnMonster = rand.Next(0, 8);
        }
        public void Attack(Player player)
        {
            // 몬스터가 플레이어 공격
            player.HP -= 
        }
    }
}
