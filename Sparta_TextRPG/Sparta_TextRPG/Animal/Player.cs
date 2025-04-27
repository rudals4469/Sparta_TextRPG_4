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
        public List<Quest> ActiveQuests { get; set; } // 진행 중인 퀘스트 저장
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public Shield Shield { get; set; }

        // Animal에 있는 inventory를 Player로 옮기기

        public Player(int Hp,int MP, int AttacPoint, int ArmorPoint, string Name ,int Gold, List<Skill> SkillList, bool IsDead, int EvasionRate, int MaxExp , ClassName className) : base(1, 0, Hp, MP, AttacPoint, ArmorPoint, Name, Gold, SkillList, EvasionRate)
        {
            this.MaxExp = MaxExp;
            this.Class = className;
            this.Inventory = new Inventory();
            this.ActiveQuests = new List<Quest>();
        }

        public bool AddExp(int exp)
        {
            this.Exp += exp;
            // 레벨업
            //레벨업 정보 전달 
            if (this.Exp >= MaxExp)
            {
                this.Level++;
                this.Exp = 0;
                this.MaxHP += 10;
                this.NowHP = this.MaxHP;
                this.MaxMP += 10;
                this.NowMP = this.MaxMP;
                this.AttackPoint += 2;
                this.ArmorPoint += 1; // 아머는 원래 0.5긴 함
                this.MaxExp += MaxExp + 25 + (Level*5);

                return true;
            }
            return false;
        }
        public void UseSkill(Skill skill)
        {
            this.NowMP -= skill.Mana;
            this.SkillList.Find(n => n.Name.CompareTo(skill.Name) == 0).NowCoolTime = 0; // 쿨돌리기
            // 스킬사용시 마나 등 사용
        }
        public void CoolDounSkill()
        {
            for (int i = 0; i < SkillList.Count; i++)
            {
                if(SkillList[i].NowCoolTime!= SkillList[i].CoolTime) SkillList[i].NowCoolTime++;
            }
        }
        public void Equiped(Item item, Player player)
        {
            // 아이템 종류 확인후 현채 작용중인 아이템과 교체
            if (item.Type == ItemType.Weapon)
            {
                
                if(Weapon != null)
                {
                    Weapon.IsEquipped = false;
                   

                    if (Weapon == (Weapon)item)
                    {
                        player.AttackPoint -= Weapon.AttackPoint;
                        Weapon = null;
                        return;
                    }
                }
                Weapon = (Weapon)item;
                Weapon.IsEquipped = true;
                player.AttackPoint += Weapon.AttackPoint;
            }
            else if (item.Type == ItemType.Armor)
            {
                if(Armor != null)
                {
                    Armor.IsEquipped = false;

                    if (Armor == (Armor)item)
                    {
                        player.ArmorPoint -= Armor.ArmorPoint;
                        Armor = null;
                        return;
                    }
                }
                
                Armor = (Armor)item;
                Armor.IsEquipped = true;
                player.ArmorPoint += Armor.ArmorPoint;
            }
            else if(item.Type == ItemType.Shield)
            {
                if (Shield != null)
                {

                    Shield.IsEquipped = false;

                    if (Shield == (Shield)item)
                    {
                        player.AttackPoint -= Shield.AttackPoint;
                        player.ArmorPoint -= Shield.ArmorPoint;
                        Shield = null;
                        return;
                    }
                }                
                Shield = (Shield)item;
                Shield.IsEquipped = true;
                player.AttackPoint += Shield.AttackPoint;
                player.ArmorPoint += Shield.ArmorPoint;
            }
        }
    }
    
}
