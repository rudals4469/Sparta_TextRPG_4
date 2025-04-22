using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Player : Animal //animal에 상속       
    {
        public int MaxExp {  get; set; } //exp
        public ClassName Class { get; set; }
        public Quest Quest { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public Shiled Shiled { get; set; }

        public Player(int Level, int Exp, int MaxHp, int NowHp, int MaxMP, int AttacPoint, int ArmorPoint,
            Inventory inventory,string Name ,int Gold, List<Skill> SkillList, bool IsDead, int EvasionRate, int MaxExp , ClassName className) : base(Level, Exp, MaxHp, NowHp, MaxHp, AttacPoint, ArmorPoint, inventory, Name, Gold, SkillList, IsDead, EvasionRate)
        {
            this.MaxExp = MaxExp;
            this.Class = className;
        }

        public void GetQuest(Quest quest)
        {
            this.Quest = quest;
        }
        public void ShowQuest()
        {
            //메세지에서 퀘스트 내용을 받아서 출력하는부분
        }
        public void ClearQuset()
        {
            //장비와 돈 받기
        }
        public void AddExp(int exp)
        {
            this.Exp += exp;
            // 레벨업
        }
        public Skill UseSkill(string SkillName)
        {
            // 스킬사용시 마나 등 사용
            return SkillList.Find(n => n.Name.CompareTo(SkillName) == 0);
        }
        public void Buy(Item item)
        {
            //상점에서 아이템 구매
        }
        public Item Sell(string itemName)
        {
            //상점에 아이템 판매
            //리턴도 새로 작성 필요
            return null;
        }
        public void usePotion(string PotionName)
        {
            //인벤토리에서 포션찾고 포션 사용하기
        }
        public void Equiped(Item item)
        {
            // 아이템 종류 확인후 현채 작용중인 아이템과 교체
        }
    }
    
}
