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
        public string Name { get; set; }
        public int Gold { get; set; }
        public List<Skill> SkillList { get; set; }
        public bool IsDead { get; set; }
        public int EvasionRate { get; set; }//회피율

        public Animal() { }
        public Animal(int Level, int Exp, int Hp, int MP, int AttacPoint, int ArmorPoint, string Name, int Gold, List<Skill> SkillList, int EvasionRate)
        {
            this.Level = Level;
            this.Exp = Exp;
            this.MaxHP = Hp;
            this.NowHP = Hp;
            this.MaxMP = MP;
            this.NowMP = MP;
            this.AttackPoint = AttacPoint;
            this.ArmorPoint = ArmorPoint;
            this.Name = Name;
            this.Gold = Gold;
            this.SkillList = SkillList;
            this.IsDead = false;
            this.EvasionRate = EvasionRate;
        }

        public int Hit(Skill skill, int PlayerDamage)
        {
            //스킬의 명중율과 나의 회피율을 잘 조합해서 회피 또는 피격
            Random rand = new Random();
            int EvasionNum = rand.Next(0, 100);
            if (EvasionNum <= EvasionRate)
            {
                return -1;
            }
            else
            {
                int CritiacalNum = rand.Next(0, 100);
                if (CritiacalNum <= skill.CriticalRate)
                {
                    NowHP -= PlayerDamage * skill.Damage * 2;
                    return PlayerDamage * skill.Damage * 2;
                }
                else
                {
                    NowHP -= PlayerDamage * skill.Damage;
                    return PlayerDamage * skill.Damage;
                }

            }
        }
    }
}
