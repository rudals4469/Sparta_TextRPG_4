using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Player : Animal //animal에 상속       
    {
        public Inventory Inventory { get; set; }
        public int MaxExp {  get; set; } //exp
        public ClassName Class { get; set; }
        public Quest Quest { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public Shiled Shiled { get; set; }
        public Player(int MaxHp,int MaxMP, int AttacPoint, int ArmorPoint, string Name ,int Gold, List<Skill> SkillList, int EvasionRate, ClassName className) : base(1, 0, MaxHp, MaxMP, AttacPoint, ArmorPoint, Name, Gold, SkillList, EvasionRate)
        {
            this.Class = className;
            this.Inventory = new Inventory();
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
            Inventory.Add(item);
            Gold -= item.Price;
        }
        public Item Sell(string itemName)
        {            
            return null;
        }
        public void usePotion(string PotionName)
        {
            Potion potion = Inventory.Potions.Find(n => n.Name.CompareTo(PotionName) == 0);
            potion.Count--;
        }
        public void Equiped(Item item)
        {
            // 아이템 종류 확인후 현채 작용중인 아이템과 교체
        }
    }
    
}
