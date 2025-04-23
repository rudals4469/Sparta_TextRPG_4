using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Sparta_TextRPG
{
    internal class Dungoun
    {
        public string Name;
        public int Level;
        public List<Monster> monsters;
        public Dungoun(string name, int level, List<Monster> monsters)
        {
            Name = name;
            Level = level;
            monsters = monsters;
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

        public void EnterDungoun()
        {
            Messages.Instance().ShowDungoun();

            string choice = Console.ReadLine();
            int level = 1;

            if (choice == "1")
            {
                level = 1;
            }
            else if (choice == "2")
            {
                level = 2;
            }
            else if (choice == "3")
            {
                level = 3;
            }
            else
            {
                Messages.Instance().ErrorMessage();
            }
        }
            


    }
}
