using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    public class Skill
    {
        public string Name { get; set; }    //스킬 이름
        public int CriticalRate { get; set; }  //크리티컬
        public string Text { get; set; }    // 스킬 설명
        public int Damage { get; set; }     //스킬 대미지(퍼센테이지로 적용,표기시 유의)
        public int Mana {  get; set; }      //마나 소모량
        public int Level { get; set; }      //스킬 레벨
        public int CoolTime { get; set; }   //스킬 쿨타임
        public int TargetCount { get; set; }
        public Skill(string name, int criticalRate, string text, int damage, int mana, int level, int coolTime, int targetCount)
        {
            Name = name;
            CriticalRate = criticalRate;
            Text = text;
            Damage = damage;
            Mana = mana;
            Level = level;
            CoolTime = coolTime;
            TargetCount = targetCount;
        }
    }    
}
