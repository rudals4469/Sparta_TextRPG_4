using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Animal
    {
        public int Level { get; set; }
        public int Exp { get; set; }
        public int MaxHP { get; set; }
        public int NowHP { get; set; }
        public int MaxMP { get; set; }
        public int NowMP { get; set; }
        public int AttackPoint { get; set; } //공격력
        public int ArmorPoint { get; set; } //방어력
        public Inventory Inventory { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }
        public List<Skill> SkillList { get; set; }
        public bool IsDead { get; set; }
        public int EvasionRate { get; set; }//회피율

    }
}
