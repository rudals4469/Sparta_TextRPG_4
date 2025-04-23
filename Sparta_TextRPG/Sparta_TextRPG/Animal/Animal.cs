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

        public Animal() { }
        public Animal(int Level, int Exp, int MaxHp, int MaxMP, int AttacPoint, int ArmorPoint,
            Inventory inventory, string Name, int Gold, List<Skill> SkillList, bool IsDead, int EvasionRate)
        {
            this.Level = Level;
            this.Exp = Exp;
            this.MaxHP = MaxHp;
            this.NowHP = MaxHp;
            this.MaxMP = MaxMP;
            this.NowHP = MaxMP;
            this.AttackPoint = AttacPoint;
            this.ArmorPoint = ArmorPoint;

            this.Inventory = inventory;
            this.Name = Name;
            this.Gold = Gold;
            this.SkillList = SkillList;
            this.IsDead = IsDead;
            this.EvasionRate = EvasionRate;
        }
    }
}
