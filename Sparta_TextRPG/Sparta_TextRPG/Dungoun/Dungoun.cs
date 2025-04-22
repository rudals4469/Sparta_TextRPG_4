using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Dungoun
    {
        public string Name;
        public int Level;
        public List<Monster> monsters;

        //생성자
        public Dungoun(string name, int level, List monsters)
        {
            Name = name;
            Level = level;
            monsters = monsters;

              
        }
    }
}
