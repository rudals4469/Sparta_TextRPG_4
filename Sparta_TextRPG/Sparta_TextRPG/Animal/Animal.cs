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
        public Animal(int Level, int Exp, int MaxHp, int MaxMP, int AttacPoint, int ArmorPoint, string Name, int Gold, List<Skill> SkillList, int EvasionRate)
        {
            this.Level = Level;
            this.Exp = Exp;
            this.MaxHP = MaxHp;
            this.NowHP = MaxHp;
            this.MaxMP = MaxMP;
            this.NowHP = MaxMP;
            this.AttackPoint = AttacPoint;
            this.ArmorPoint = ArmorPoint;
            this.Name = Name;
            this.Gold = Gold;
            this.SkillList = SkillList;
            this.IsDead = false;
            this.EvasionRate = EvasionRate;
        }

        public void Hit(int Damege)
        {
            this.NowHP -= Damege;
        }
        public Skill? useSkill(string skillName)
        {
            Skill? skill = SkillList.Find(n => n.Name.CompareTo(skillName) == 0);
            return skill;
        }//플레이어와 몬스터 스킬사용 로직이 다름
        public bool Evasion(Skill skill,int PlayerDamage)
        {
            //스킬의 명중율과 나의 회피율을 잘 조합해서 회피 또는 피격
            Random rand = new Random();
            int EvasionNum = rand.Next(0, 100);
            if(EvasionNum<= EvasionRate)
            {
                return false;
            }
            else
            {
                int CritiacalNum = rand.Next(0, 100);
                if(CritiacalNum<= skill.CriticalRate)
                {
                    Hit(PlayerDamage * skill.Damage * 2);
                }
                else
                {
                    Hit(PlayerDamage * skill.Damage);
                }
                return true;
            }

        }
    }
}
