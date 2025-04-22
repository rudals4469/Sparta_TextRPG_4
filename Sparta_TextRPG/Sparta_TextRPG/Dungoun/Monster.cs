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

  
        public Monster(int Level, int Exp, int MaxHp, int NowHp, int MaxMP, int AttacPoint, int ArmorPoint,
            Inventory inventory,int Gold, List<Skill> SkillList, bool IsDead, int EvasionRate, MonsterName MonsterName, List<Item> Items) : base(Level, Exp, MaxHp,NowHp,MaxHp,AttacPoint,ArmorPoint,inventory, MonsterName.ToString(), Gold,SkillList,IsDead,EvasionRate)
        {
            this.MonsterName = MonsterName;
            this.Items = Items;
        } // Monster 생성자
       
        public void show(Monster monster)
        {
            Console.Write(
           $"""
               Lv.{monster.Level} {monster.MonsterName}) HP {monster.NowHP}
                
            """);

        }
    }
}
