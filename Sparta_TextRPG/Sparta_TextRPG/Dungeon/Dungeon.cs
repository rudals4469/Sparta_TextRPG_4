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
        public void DunjeonReset()
        {
            Random rand = new Random();
            for (int i = 0; i < rand.Next(3,4); i++)
            {
                int randnum = rand.Next(0, baseMonsters.Count);
                monsters.Add(baseMonsters[randnum]);
            }

            
        }
        public void SpawnMonster() // 몬스터 랜덤 생성
        {
            Random rand = new Random();
            int SpawnMonster = rand.Next(0, 8); // 0~7번 까지의 인덱스

            int MonsterCount = rand.Next(1, 5); // 1~4 마리의 몬스터 소환 변수

            for (int i = 0; i < MonsterCount; i++)
            {
                // 몬스터 생성

                // 몬스터 정보 출력
            }
        }          

    }
}
