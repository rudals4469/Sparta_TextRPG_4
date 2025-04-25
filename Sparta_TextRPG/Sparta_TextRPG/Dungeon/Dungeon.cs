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
            monsters = new List<Monster>();

            Random rand = new Random();
            for (int i = 0; i < rand.Next(3,4); i++)
            {
                int randnum = rand.Next(0, baseMonsters.Count);

                monsters.Add(baseMonsters[randnum].Cope());
            }
            
        }       

    }
}
