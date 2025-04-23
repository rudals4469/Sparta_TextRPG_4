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
        public Shield Shield { get; set; }

        // Animal에 있는 inventory를 Player로 옮기기

        public Player(int Hp,int MP, int AttacPoint, int ArmorPoint, string Name ,int Gold, List<Skill> SkillList, bool IsDead, int EvasionRate, int MaxExp , ClassName className) : base(1, 0, Hp, MP, AttacPoint, ArmorPoint, Name, Gold, SkillList, EvasionRate)
        {
            this.MaxExp = MaxExp;
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
            if (this.Exp > MaxExp)
            {
                this.Level++;
                this.Exp = 0;
                this.AttackPoint += 1;
                this.ArmorPoint += 1; // 아머는 원래 0.5긴 함
            }
        }
        public void UseSkill(Skill skill)
        {
            this.NowMP -= skill.Mana;
            // 스킬사용시 마나 등 사용
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
        public void usePotion(Potion potion, Player player)
        {

            //Potion potion = Inventory.Potions.Find(n => n.Name.CompareTo(potion.Name) == 0);
            potion.Count--;
            //인벤토리에서 포션찾고 포션 사용하기
            if(player.Inventory.Potions.Count > 0)
            {
                
            }

            // 포션의 타입이 맞으면
            // 인벤토리에서 포션이 있으면
            // 포션 사용

        }
        public void Equiped(Item item, Player player)
        {
            // 아이템 종류 확인후 현채 작용중인 아이템과 교체
            if (item.Type == ItemType.Weapon)
            {
                
                if(Weapon != null)
                {
                    Weapon.IsEquipped = false;
                    if (Weapon == (Weapon)item) return;
                }
                Weapon = (Weapon)item;
                Weapon.IsEquipped = true;

            }
            else if (item.Type == ItemType.Armor)
            {
                if (Armor != null)
                {
                    Armor.IsEquipped = false;
                    if (Armor == (Armor)item) return;
                }
                Armor = (Armor)item;
                Armor.IsEquipped = true;
            }
            else if(item.Type == ItemType.Shield)
            {
                if (Shield != null)
                {
                    Shield.IsEquipped = false;
                    if (Shield == (Shield)item) return;
                }
                Shield = (Shield)item;
                Shield.IsEquipped = true;
            }
        }
    }
    
}
