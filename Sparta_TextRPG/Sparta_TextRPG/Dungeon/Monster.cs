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
        public MonsterName MonsterName;
        List<Item> Items;
        Skill NextAttack;
        public Monster():base() { }
        public Monster(int Level, int Exp, int MaxHp, int MaxMP, int AttacPoint, int ArmorPoint, int Gold, List<Skill> SkillList,int EvasionRate, MonsterName MonsterName, List<Item> Items) : base(Level, Exp, MaxHp,MaxHp,AttacPoint,ArmorPoint, MonsterName.ToString(), Gold,SkillList,EvasionRate)
        {
            this.MonsterName = MonsterName;
            this.Items = Items;
            NextAttack = SkillList[0];
        } // Monster 생성자
       
        public void show(Monster monster)
        {
            Console.Write(
           $"""
               Lv.{monster.Level} {monster.MonsterName}) HP {monster.NowHP}
                
            """);

        }
        public Item? DropItem()
        {
            Random rand = new Random();
            int dorpP = rand.Next(0,100);
            if (dorpP > 50)
            {
                int itemNum = rand.Next(0,5);
                return Items[itemNum];
            }
            else
            {
                return null;
            }
        }
        // 스킬 사용
        // 스킬 사용 - > 새로운 스킬 사용예정 -> 
        // 스킬사용시 쿨이 0이 아니면 넘어 가기
        public Skill? useSkill(string skillName)
        {
            Skill? skill = SkillList.Find(n => n.Name.CompareTo(skillName) == 0);
            return skill;
        }//플레이어와 몬스터 스킬사용 로직이 다름
        // public bool Evasion(Skill skill,int PlayerDamage)

        //몬스터 공격
    }
}
