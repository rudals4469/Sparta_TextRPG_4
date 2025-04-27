using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Sparta_TextRPG
{
    internal class Dungeon
    {
        public string Name;
        public int Level;
        public List<Monster> baseMonsters;
        public List<Monster> monsters;
        public Dungeon(string name, int level, List<Monster> baseMonsters)
        {
            Name = name;
            Level = level;
            this.baseMonsters = baseMonsters;
            monsters = new List<Monster>();
        }
        public void DungeonReset()
        {
            monsters = new List<Monster>();

            Random rand = new Random();
            for (int i = 0; i < rand.Next(3,5); i++)
            {
                int randnum = rand.Next(0, baseMonsters.Count);
                // 던전에서 나올 수 있는 몬스터 풀

                monsters.Add(baseMonsters[randnum].Cope());
                // 그냥 복사하면 참조 복사가 되어서 Cope()를 사용해서
                // 각 자의 객체로 복사가 되게 한다.
            }
            
        }       


    }
}
