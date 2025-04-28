
using Sparta_TextRPG.Utill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sparta_TextRPG
{
    internal class Messages
    {
        static Messages instance;
        public static Messages Instance()
        {
            if (instance == null)
            {
                instance = new Messages();
            }
            return instance;
        }
        public void ConsoleSPMS()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(
                """

                  ███████╗██████╗  █████╗ ██████╗ ████████╗ █████╗                      
                  ██╔════╝██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗                                       
                  ███████╗██████╔╝███████║██████╔╝   ██║   ███████║                                        
                  ╚════██║██╔═══╝ ██╔══██║██╔══██╗   ██║   ██╔══██║                                         
                  ███████║██║     ██║  ██║██║  ██║   ██║   ██║  ██║                     
                  ╚══════╝╚═╝     ╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝                     
                  ███╗   ███╗ █████╗ ██████╗ ██╗     ███████╗    ███████╗████████╗ ██████╗ ██████╗ ██╗   ██╗
                  ████╗ ████║██╔══██╗██╔══██╗██║     ██╔════╝    ██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗╚██╗ ██╔╝
                  ██╔████╔██║███████║██████╔╝██║     █████╗      ███████╗   ██║   ██║   ██║██████╔╝ ╚████╔╝ 
                  ██║╚██╔╝██║██╔══██║██╔═══╝ ██║     ██╔══╝      ╚════██║   ██║   ██║   ██║██╔══██╗  ╚██╔╝  
                  ██║ ╚═╝ ██║██║  ██║██║     ███████╗███████╗    ███████║   ██║   ╚██████╔╝██║  ██║   ██║   
                  ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝     ╚══════╝╚══════╝    ╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝                                                                                                           
                
                """);
        }
        public void ShowStart()
        {
            Console.Write(
                """     

                메이플 월드에 오신 여러분 환영합니다.
                이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

                ┌────────────────────────┐
                │ 1.상태 보기            │
                │                        │
                │ 2.상점                 │
                │                        │
                │ 3.던전입장             │
                │                        │
                │ 4.여관으로 가기        │
                │                        │
                │ 5.게임종료             │
                └────────────────────────┘

                원하시는 행동을 입력해주세요.
                >> 
                """);
        }
        public void ShowStartSetName()
        {            
            Console.Write($"""
                ┌─────────────────────────────────────┐
                │                                     │
                │ 메이플 월드에 오신여러분 환영합니다.│                
                │ 원하시는 이름을 설정해주세요.       │
                │                                     │
                └─────────────────────────────────────┘
                
                >> 
                """);
        }
        public void ShowStartChackName(string Name)
        {
            Console.Write($"""
                
                ┌─────────────────────────────────────┐
                │                                     │
                │ 메이플 월드에 오신여러분 환영합니다.│                
                │ 원하시는 이름을 설정해주세요.       │
                │                                     │
                └─────────────────────────────────────┘

                 입력하신 이름은 {Name}입니다.

                ┌─────────┐
                │ 1.저장  │
                │ 2.취소  │
                └─────────┘

                원하시는 행동을 입력해주세요
                >> 
                """);
        }
        public void ShowStartSetClass()
        {

            Console.Write($"""

                ┌─────────────────────────────────────┐
                │ 메이플 월드에 오신여러분 환영합니다.│
                │ 원하시는 직업을 설정해주세요.       │
                └─────────────────────────────────────┘

                ┌──────────────────────────────────────────────────────┐
                │ 1.{ClassName.전사.ToString()} : 강한 공격력과 체력을 지니고 있는 탱커       │
                │ 2.{ClassName.법사.ToString()} : 화려하고 강력한 속성 공격의 대가            │
                │ 3.{ClassName.궁수.ToString()} : 빠르고 강력한 원거리 공격을 하는 저격 마스터│ 
                │ 4.{ClassName.도적.ToString()} : 그림자에서 공격을 퍼붓는 암살자             │ 
                │ 5.{ClassName.해적.ToString()} : 노틸러스 호를 타고 여행하는 모험가          │
                └──────────────────────────────────────────────────────┘
                
                원하시는 행동을 입력해주세요
                >> 
                """);

        }
        public void ShowStatus(Player player) 
        {

            Console.WriteLine("\n┌ [상태 보기]───────────────┐");
            Console.WriteLine($"│ Lv. {player.Level,22}│");

            string text = $"{player.Name}";
            string print = "";
            for (int i = 0; i < 26 - GetStringWidth(text); i++)
            {
                print += " ";
            }
            print += text;
            Console.WriteLine($"│ {print}│");
            Console.WriteLine($"│ {"직  업"}:  {player.Class,15}│");
            Console.WriteLine($"│ {"공격력"}: {player.AttackPoint,18}│");
            Console.WriteLine($"│ {"방어력"}: {player.ArmorPoint,18}│");

            text = $"{"체  력"}: ";
            string text2 = $"{player.NowHP} / {player.MaxHP}";
            print = "";
            print += text; 
            for (int i = GetStringWidth(text); i < 26- GetStringWidth(text2); i++)
            {
                print += " ";
            }
            print += text2;

            Console.WriteLine($"│ {print}│");
            Console.WriteLine($"│ {"경험치"}: {player.Exp,13} / {player.MaxExp}│");
            Console.WriteLine($"│ {"Gold"}: {player.Gold,15} Meso│");
            Console.WriteLine("└───────────────────────────┘");


            Console.WriteLine("\n┌ [인벤토리]───────────────────┐");
            text = $" - {"무기",-4} :";

            if (player.Weapon != null) text2 = $" {player.Weapon.Text}";
            else text2 = "";

            print = "";
            print += text;
            print += text2;
            for (int i = GetStringWidth(text); i < 30 - GetStringWidth(text2); i++)
            {
                print += " ";
            }
                    

            Console.WriteLine($"│{print}│");

            text = $" - {"방어구",-3} :";

            if (player.Armor != null) text2 = $" {player.Armor.Text}";
            else text2 = "";

            print = "";
            print += text;
            print += text2;
            for (int i = GetStringWidth(text); i < 30 - GetStringWidth(text2); i++)
            {
                print += " ";
            }


            Console.WriteLine($"│{print}│");

            text = $" - {"방패",-4} :";

            if (player.Shield != null) text2 = $" {player.Shield.Text}";
            else text2 = "";

            print = "";
            print += text;
            print += text2;
            for (int i = GetStringWidth(text); i < 30 - GetStringWidth(text2); i++)
            {
                print += " ";
            }


            Console.WriteLine($"│{print}│");
            Console.WriteLine("└──────────────────────────────┘");

            Console.WriteLine("\n1. 인벤토리 보기");
            Exit();
        }
        public void ShowInventory(Player player)
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

            int totalItemCount = player.Inventory.Weapon.Count
                                + player.Inventory.Armors.Count
                                + player.Inventory.Shild.Count
                                + player.Inventory.Potions.Count;
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────┐");
            if (totalItemCount == 0)
            {
                Console.WriteLine("│                         아이템이 없습니다.                         │");
            }
            else
            {
                Console.WriteLine("│ [무기]                                                             │\n│                                                                    │");
                foreach (var weapon in player.Inventory.Weapon)
                {
                    string prefix = weapon.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {prefix}{weapon.Text} | {weapon.Price,-5} Meso | 공격력 + {weapon.AttackPoint} ");
                }
                Console.WriteLine("├────────────────────────────────────────────────────────────────────┤");
                Console.WriteLine("│ [방어구]                                                           │\n│                                                                    │");

                Console.WriteLine("\n[방어구]\n");
                foreach (var armor in player.Inventory.Armors)
                {
                    string prefix = armor.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {prefix}{armor.Text} | {armor.Price,-5} Meso | 방어력 + {armor.ArmorPoint}");
                }
                Console.WriteLine("├────────────────────────────────────────────────────────────────────┤");
                Console.WriteLine("│ [방패]                                                             │\n│                                                                    │");

                Console.WriteLine("\n[방패]\n");
                foreach (var shield in player.Inventory.Shild)
                {
                    string prefix = shield.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {prefix}{shield.Text} | {shield.Price,-5} Meso | 공격력 + {shield.ArmorPoint} 방어력 + {shield.AttackPoint}");
                }
                Console.WriteLine("├────────────────────────────────────────────────────────────────────┤");
                Console.WriteLine("│ [포션]                                                             │\n│                                                                    │");

                Console.WriteLine("\n[포션]\n");

                var potions = from potion in player.Inventory.Potions
                              orderby potion.Name ascending
                              group potion by potion.Name into g
                              select new
                              {
                                  Name = g.Key,
                                  Count = g.Count(),
                                  Text = g.First().Text,
                                  Potion = g.First().PotionType

                              };
                foreach (var potion in potions)
                {
                    Console.WriteLine($"-  {potion.Name,-18} | {potion.Text} | x{potion.Count}");
                }

            }
            Console.WriteLine("└────────────────────────────────────────────────────────────────────┘");

            Console.WriteLine("\n1. 장착 관리");
            Exit();


            /*if (input == "0") break;
            else if (input == "1") ManageEquipment(player); 
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.ReadKey();
            } 메세지 파일에서는 출력만 담당합니다. 기능들은 메이플알피지 파일에서 */

        }
        public void ManageEquipment(Player player)
        {
            // 장착 관리
            Console.WriteLine("\n인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");


            int totalItemCount = player.Inventory.Weapon.Count
                                   + player.Inventory.Armors.Count
                                   + player.Inventory.Shild.Count
                                   + player.Inventory.Potions.Count;

            int Count = 1;


            if (totalItemCount == 0)
            {
                Console.WriteLine("┌────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│                         아이템이 없습니다.                         │");
                Console.WriteLine("└────────────────────────────────────────────────────────────────────┘\n");
            }
            else
            {
                Console.WriteLine("┌────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│ [무기]                                                             │\n│                                                                    │");

                foreach (var weapon in player.Inventory.Weapon)
                {
                    string prefix = weapon.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"│ - {Count,-2} {prefix}{weapon.Text} | {weapon.Price,-5} Meso | 공격력 + {weapon.AttackPoint,-7}           │ ");
                    Count++;
                }

                Console.WriteLine("├────────────────────────────────────────────────────────────────────┤");
                Console.WriteLine("│ [방어구]                                                           │\n│                                                                    │");
                foreach (var armor in player.Inventory.Armors)
                {
                    string prefix = armor.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"│ - {Count,-2} {prefix}{armor.Text} | {armor.Price,-5} Meso | 방어력 + {armor.ArmorPoint,-7}           │");
                    Count++;
                }

                Console.WriteLine("├────────────────────────────────────────────────────────────────────┤");
                Console.WriteLine("│ [방패]                                                             │\n│                                                                    │");
                foreach (var shield in player.Inventory.Shild)
                {
                    string prefix = shield.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"│ - {Count,-2} {prefix}{shield.Text} | {shield.Price,-5} Meso | 공격력 + {shield.ArmorPoint} 방어력 + {shield.AttackPoint,-7}│");
                    Count++;
                }

                Console.WriteLine("└────────────────────────────────────────────────────────────────────┘");

            }

            Exit();

        }
        public void ShowShop(Player player, Shop shop)
        {
            int Count = 1;

            Console.Write($"""
                상점에 오신 것을 환영합니다!
                필요한 아이템을 골드로 구매하실 수 있습니다 :3

                [보유 골드]
                {player.Gold} Meso
                
                [아이템 목록]

                """);



            Console.WriteLine("\n┌ [무기]──────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                             │");
            foreach (var weapon in shop.Inventory.Weapon)
            {
                Console.WriteLine($"│  - {Count,-2} {weapon.Text} │" +
                    $" {weapon.Price,-5} Meso │ 공격력 + {weapon.AttackPoint}             │");
                Count++;
            }
            Console.WriteLine("│                                                             │");

            Console.WriteLine("├ [방어구]────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                             │");
            foreach (var armor in shop.Inventory.Armors)
            {

                Console.WriteLine($"│  - {Count,-2} {armor.Text} │ {armor.Price,-5} Meso │ 방어력 + {armor.ArmorPoint}             │");
                Count++;
            }
            Console.WriteLine("│                                                             │");
            Console.WriteLine("├ [방패]──────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                             │");
            foreach (var shield in shop.Inventory.Shild)
            {

                Console.WriteLine($"│  - {Count,-2} {shield.Text} │ {shield.Price,-5} Meso │ 공격력 + {shield.ArmorPoint} 방어력 + {shield.AttackPoint}  │");
                Count++;
            }

            Console.WriteLine("│                                                             │");
            Console.WriteLine("├ [포션]──────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                             │");
            foreach (var potion in shop.Inventory.Potions)
            {
                Console.WriteLine($"│  - {Count,-2} {potion.Text} │ {potion.Price,-5} Meso │ {potion.HealPoint} 회복               │");
                Count++;
            }
            Console.WriteLine("│                                                             │");
            Console.WriteLine("""
                └─────────────────────────────────────────────────────────────┘

                1. 아이템 구매
                2. 아이템 판매

                """);
            Exit();


        }
        public void BuyItem(Player player, Shop shop)
        {
            int Count = 1;

            Console.Write($"""
                상점에 오신 것을 환영합니다!
                필요한 아이템을 골드로 구매하실 수 있습니다 :3

                [보유 골드]
                {player.Gold} Meso
                
                [아이템 목록]


                """);
            Console.WriteLine("\n┌ [무기]──────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                             │");
            foreach (var weapon in shop.Inventory.Weapon)
            {
                Console.WriteLine($"│  - {Count,-2} {weapon.Text} │ {weapon.Price,-5} Meso │ 공격력 + {weapon.AttackPoint}             │");
                Count++;
            }

            Console.WriteLine("│                                                             │");
            Console.WriteLine("├ [방어구]────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                             │");

            foreach (var armor in shop.Inventory.Armors)
            {
                Console.WriteLine($"│  - {Count,-2} {armor.Text} │ {armor.Price,-5} Meso │ 방어력 + {armor.ArmorPoint}             │");
                Count++;
            }

            Console.WriteLine("│                                                             │");
            Console.WriteLine("├ [방패]──────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                             │");
            foreach (var shield in shop.Inventory.Shild)
            {

                Console.WriteLine($"│  - {Count,-2} {shield.Text} │ {shield.Price,-5} Meso │ 공격력 + {shield.ArmorPoint} 방어력 + {shield.AttackPoint}  │");
                Count++;
            }

            Console.WriteLine("│                                                             │");
            Console.WriteLine("├ [포션]──────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                             │");
            foreach (var potion in shop.Inventory.Potions)
            {
                Console.WriteLine($"│  - {Count,-2} {potion.Text} │ {potion.Price,-5} Meso │ {potion.HealPoint} 회복               │");
                Count++;
            }

            Console.WriteLine("│                                                             │");
            Console.Write("""
                └─────────────────────────────────────────────────────────────┘

                0. 나가기

                번호를 눌러 원하는 아이템을 사거나 원하시는 행동을 입력해주세요.
                >> 
                """);


        }
        public void SellItem(Player player, Shop shop)
        {
            int Count = 1;

            Console.Write($"""
                상점에 오신 것을 환영합니다!
                필요한 아이템을 판매하실 수 있습니다 :3

                [보유 골드]
                {player.Gold} Meso
                
                [아이템 목록]


                """);



            Console.WriteLine("\n┌ [무기]──────────────────────────────────────────────────────┐");
            Console.WriteLine("│                                                             │");
            foreach (var weapon in player.Inventory.Weapon)
            {
                Console.WriteLine($"│  - {Count,-2} {weapon.Text} │ {weapon.Price,-5} Meso │ 공격력 + {weapon.AttackPoint}             │");
                Count++;
            }
            Console.WriteLine("│                                                             │");
            Console.WriteLine("├ [방어구]────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                             │");
            foreach (var armor in player.Inventory.Armors)
            {

                Console.WriteLine($"│  - {Count,-2} {armor.Text} │ {armor.Price,-5} Meso │ 방어력 + {armor.ArmorPoint}             │");
                Count++;
            }

            Console.WriteLine("│                                                             │");
            Console.WriteLine("├ [방패]──────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                             │");
            foreach (var shield in player.Inventory.Shild)
            {

                Console.WriteLine($"│  - {Count,-2} {shield.Text} │ {shield.Price,-5} Meso │ 공격력 + {shield.ArmorPoint} 방어력 + {shield.AttackPoint}  │");
                Count++;
            }
            Console.WriteLine("│                                                             │");
            Console.WriteLine("├ [포션]──────────────────────────────────────────────────────┤");
            Console.WriteLine("│                                                             │");

            //var potions = from potion in player.Inventory.Potions
            //              group potion by potion.PotionType into g
            //              orderby g.Key
            //              select new
            //              {

            //                  Name = g.First().Name,
            //                  Count = g.Count(),
            //                  Text = g.First().Text,
            //                  Potion = g.Key,
            //                  Price = g.First().Price,
            //                  HealPoint = g.First().HealPoint

            //              };

            //foreach (var potion in potions)
            //{
            //    Console.WriteLine($"- {Count,-2} {potion.Text} |
            //    {potion.Price,-5} Meso | {potion.HealPoint} 회복 ");
            //    Count++;
            //}
            var potionssearch = player.Inventory.Potions.OrderBy(p => p.PotionType);

            foreach (var potion in potionssearch)
            {
                Console.WriteLine($"│  - {Count,-2} {potion.Text} | {potion.Price,-5} Meso | {potion.HealPoint} 회복               │");
                Count++;
            }


            Console.WriteLine("│                                                             │");
            Console.Write("""
                └─────────────────────────────────────────────────────────────┘

                0. 나가기

                번호를 눌러 원하는 아이템을 팔거나 원하시는 행동을 입력해주세요.
                >> 
                """);
        }
        public void NotEnoughMoney()
        {
            Console.WriteLine("[실패] 골드가 부족합니다. 아무 숫자를 눌러 상점으로 돌아가세요.");
        }
        public void ShowDungoun(List<Dungeon> dungouns)
        {
            Console.Write($"""
               ┌[던전입장]───────────────────────┐
               │이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다. │
               """);
            foreach (var item in dungouns)
            {
                Console.WriteLine($"{item.Name} | 던전 레벨 : {item.Level}");
            }
            ;
            Exit();
        }
        public void ShowDungeonSelection(List<Dungeon> dungouns)
        {
            int count = 0;
            Console.WriteLine("\n┌ [던전 선택]──────────────────────────────────────────────────────────────────────┐");
            foreach (var item in dungouns)
            {
                Console.Write($"│{++count,2}. {item.Name} | 권장 레벨 : {item.Level} 등장 몬스터 :");
                string print = "";
                foreach (var item1 in item.baseMonsters)
                {
                    if (item1.Level >= 10) print += $" ? ";
                    else print += $" {item1.Name,-4}";
                }
                for (int i = GetStringWidth(print); i < 43; i++)
                {
                    print += " ";
                }
                Console.WriteLine($"{print}│");
            }
            Console.Write($"""
                │                                                                                  │
                ├ [탐색 준비]──────────────────────────────────────────────────────────────────────│
                │ {++count}. 상태 보기                                                                    │ 
                │ {++count}. 회복 아이템                                                                  │
                └──────────────────────────────────────────────────────────────────────────────────┘


                """);
            Exit();
        }
        public void printMonster(List<Monster> monsters)
        {
            int count = 0;

            Console.WriteLine("┌ [몬스터]────────────────────────────────┐");
            foreach (var item in monsters)
            {
                count++;
                string print = "";
                if (item.IsDead)
                {
                    Console.Write("│");
                    Console.ForegroundColor = ConsoleColor.Red;
                    print = $" {count} Lv.{item.Level} {item.MonsterName.ToString()} Dead";
                    for (int i = GetStringWidth(print); i < 41; i++)
                    {
                        print += " ";
                    }
                    Console.Write($"{print}");
                    Console.ResetColor();
                    Console.WriteLine("│");
                }
                else
                {
                    print = $"│ {count} Lv.{item.Level} {item.MonsterName.ToString()} HP:{item.NowHP}";
                    for (int i = GetStringWidth(print); i < 43; i++)
                    {
                        print += " ";
                    }
                    Console.WriteLine($"{print}│");
                }

                
            }
            Console.WriteLine("└─────────────────────────────────────────┘");
        }
        public void ShowBattleStart(List<Monster> monsters, Player player)
        {

            printMonster(monsters);

            Console.Write(
               $"""

               ┌ [내정보]────────────┐
               │ Lv.{player.Level} {player.Name,-6} ({player.Class.ToString()})  │
               │ HP {player.NowHP,-3}/{player.MaxHP,-13}│
               │ Mp {player.NowMP,-3}/{player.MaxMP,-13}│ 
               └─────────────────────┘

               1.스킬 선택

               원하시는 행동을 입력해주세요.
               >> 
               """
                );

        }
        public void ShowSellectSkill(List<Monster> monsters, Player player)
        {
            printMonster(monsters);

            Console.WriteLine(
               $"""

               ┌ [내정보]────────────┐
               │ Lv.{player.Level} {player.Name,-6} ({player.Class.ToString()})  │
               │ HP {player.NowHP,-3}/{player.MaxHP,-13}│
               │ Mp {player.NowMP,-3}/{player.MaxMP,-13}│ 
               └─────────────────────┘
               
               """);
            int count = 0;

            Console.WriteLine("┌ [No]── [이름]───────── [마나]── [쿨타임]─── [설명] ──────────────────────────────────────┐");
            foreach (var item in player.SkillList)
            {
                string print = $"{++count,-2} | {item.Name,-14} | {item.Mana,4}  | {item.NowCoolTime,3}/{item.CoolTime,3}   | {item.Text}";
                for (int i = GetStringWidth(print); i < 89; i++)
                {
                    print += " ";
                }
                Console.WriteLine($"│ {print}│");   
            }
            Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────────┘");
            Console.Write("""

                원하시는 행동을 입력해주세요.
                >> 
                """);
        }
        public void CoolTimeError()
        {
            Console.WriteLine(
                $"""
                ┌────────────────────────────────────────────────┐
                """);
            Console.WriteLine("│ [스킬 사용 불가] 쿨타임 중이므로 다른 스킬을 사용해주세요.");
            Console.Write(
                """                
                └────────────────────────────────────────────────┘                    
                """);
            //Thread.Sleep(3000);
        }
        public void ShowBattleAttackPhase(List<Monster> monsters, Player player)
        {
            printMonster(monsters);

            Console.Write(
               $"""


               ┌ [내 정보]───────────────────────────────┐
               
               """);
            string print = "";
            string print2 = "";


            print = $"│ Lv.{player.Level} {player.Name} ({player.Class.ToString()})";
            print2 = $"│ HP {player.NowHP}/{player.MaxHP}";

            for (int i = GetStringWidth(print); i < 43; i++)
            {
                print += " ";
            }
            for (int i = GetStringWidth(print2); i < 43; i++)
            {
                print2 += " ";
            }
            Console.WriteLine($"{print}│");
            Console.WriteLine($"{print2}│");

            Console.Write($"""
               └─────────────────────────────────────────┘
           

                0.취소

               대상을 선택해주세요
               >> 
               """
             );
        }
        public void ShowBattleAttackMonster(Monster monster,int monsterbeforHP, Player player, int Damage)
        {
            Console.WriteLine(
                $"""
                ┌────────────────────────────────────────────────┐
                """);

            if (Damage > 0)
            {

                string print = "";

                string print2 = "";

                print = $"│ {player.Name} 의 공격!";
                print2 = $"│ Lv.{monster.Level} {monster.MonsterName.ToString()}을(를) 맞췄습니다. [데미지 : {Damage}]";
                for (int i = GetStringWidth(print); i < 50; i++)
                {
                    print += " ";
                }
                for (int i = GetStringWidth(print2); i < 50; i++)
                {
                    print2 += " ";
                }
                Console.WriteLine($"{print}│");
                Console.WriteLine($"{print2}│");


                string print3 = $"│ LV.{monster.Level} {monster.MonsterName.ToString()} ";
                if (monster.IsDead)
                {
                    print3 += $"HP {monsterbeforHP} -> Dead";
                }
                else
                {
                    print3 += $"HP {monsterbeforHP} -> {monsterbeforHP - Damage}";
                }
                for (int i = GetStringWidth(print3); i < 50; i++)
                {
                    print3 += " ";
                }
                Console.WriteLine($"{print3}│");

            }
            else
            {
                Random random = new Random();
                int n = random.Next(0, 100);
                string print = "";



                if (n % 5 == 0)
                {
                    print += $"│ {monster.Name}이(가) {player.Name}님의 공격을 \"훗\" 하고 피함";
                }
                else
                {
                    print += $"│ {monster.Name}이(가) {player.Name}님의 공격을 슉 슈슉 슉하고 피함";
                }//회피 문구 추가하기

                for (int i = GetStringWidth(print); i < 50; i++)
                {
                    print += " ";
                }
                Console.WriteLine($"{print}│");
                
            }
            Console.Write(
                """                
                └────────────────────────────────────────────────┘                    
                """);

            Console.Write(
                $"""
                 

               0. 다음
               
               >> 
               """);

        }
        public void ShowBattleMonsterPhase()
        {
            Console.Write(
               $"""
               ┌──[Battle!!]────────────────────────────────────┐              

               """);
        }
        public void ShowBattleMonsterHitPhase(Monster monster,int beforHp ,Player player, int Damage)
        {
            if (Damage > 0)
            {
                string print = "";

                string print2 = "";

                print = $"│ Lv. {monster.Level} {monster.MonsterName.ToString()} 의 공격!";
                print2 = $"│{player.Name} 을(를) 맞췄습니다.  [데미지 : {Damage}]";
                for (int i = GetStringWidth(print); i < 50; i++)
                {
                    print += " ";
                }
                for (int i = GetStringWidth(print2); i < 50; i++)
                {
                    print2 += " ";
                }
                Console.WriteLine($"{print}│");
                Console.WriteLine($"{print2}│");


                string print3 = $"│ Lv.{player.Level} {player.Name} ";
                if (player.IsDead)
                {
                    print3 += $"HP {beforHp} -> Dead";
                }
                else
                {
                    print3 += $"HP {beforHp} -> {beforHp - Damage}";
                }
                for (int i = GetStringWidth(print3); i < 50; i++)
                {
                    print3 += " ";
                }
                Console.WriteLine($"{print3}│");

            }
            else
            {
                Random random = new Random();
                int n = random.Next(0, 100);
                string print = "";

                if (n % 2 == 0)
                {
                    print += $"│ {player.Name}님이 {monster.Name}의 공격을 \"훗\" 하고 피함";
                }
                else
                {
                    print += $"│ {player.Name}님이 {monster.Name}의 공격을 슉 슈슉 슉하고 피함";
                }//회피 문구 추가하기

                for (int i = GetStringWidth(print); i < 50; i++)
                {
                    print += " ";
                }
                Console.WriteLine($"{print}│");

            }


        }
        public void ShowBattleMonsterEndPhase()
        {
            Console.WriteLine(
                """                
                └────────────────────────────────────────────────┘                    
                """);

            Console.Write(
              $"""
               0. 전투 시작화면으로  
               >> 
               """);
        }
        public void ShowBattlePlayerWin(List<Monster> monsters, int HP, Player player, List<Item> items)
        {
            Console.Write(
               $"""
               Battle!! - Result

               Victory

               던전에서 몬스터 {monsters.Count}마리를 잡았습니다.

               Lv.{player.Level} {player.Name}
               HP {HP} -> {player.NowHP}

               획득 아이템
               (
               """);
            for (int i = 0; i < items.Count; i++)
            {
                Console.Write($"{items[i].Text}");
                if(i != items.Count) Console.Write($",");
            }
            foreach (var item in items)
            {
                Console.Write($"{item.Text}");
            }

        }
        public void LevelUp(Player player)
        {
            Console.WriteLine("[Level Up]");
            Console.WriteLine();
            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine($"{player.Name} ({player.Class})");
            Console.WriteLine($"{"공격력",-5}: {player.AttackPoint}");
            Console.WriteLine($"{"방어력",-5}: {player.ArmorPoint}");
            Console.WriteLine($"{"체  력",-6}: {player.NowHP} / {player.MaxHP}");
            Console.WriteLine($"{"경험치",-5}: {player.Exp} / {player.MaxExp}");
            Console.WriteLine($"{"Gold",-8}: {player.Gold} Meso");
            Console.WriteLine();
        }
        public void ShowBattlePlayerWinLest()
        {
            Console.Write(
               """
               )
               0. 다음

               >> 
               """);
        }
        public void ShowBattlePlayerLose(int HP, Player player)
        {
            Console.Write(
               $"""
               Battle!! - Result

               You Lose

               Lv.{player.Level} {player.Name}
               HP {HP} -> {player.NowHP}

               0. 다음
               >> 
               """);
        }
        public void DrinkingPotion(Player player)//던전에서 포션마시기를 눌렀을 때 나오는 메세지
        {
            int HpPotionCount = player.Inventory.Potions.Count(p => p.PotionType == PotionType.HP);
            int MpPotionCount = player.Inventory.Potions.Count(p => p.PotionType == PotionType.MP);
            int AlixirCount = player.Inventory.Potions.Count(p => p.PotionType == PotionType.Alixir);
            Console.Write($"""

                ┌ [소유 포션]───────────────┐
                │ 1. HP 포션 | +100HP ({HpPotionCount}개) │
                │ 2. MP 포션 | +100MP ({MpPotionCount}개) │ 
                │ 3. 엘릭서  | +500HP ({AlixirCount}개) │
                └───────────────────────────┘

                0. 나가기

                사용하실 포션을 입력해주세요.
                >> 
                """);
        }
        public void DrinkingPotion(Player player, int before, PotionType potionType)//포션마시기에서 hp 포션을 눌렀을 때 나오는 메세지
        {
            int recovered = player.NowHP - before;
            Console.Clear();
            Console.WriteLine($"""
            [{potionType.ToString()} 포션 사용!]

            {before} → {player.NowHP} ( +{recovered} 회복 )
            """);
            Console.WriteLine("\n포션 선택 화면으로 돌아가시려면 아무 키나 입력하세요.");
            Console.Write(">>");
            Console.ReadLine();
        }
        public void Full(PotionType potionType)
        {
            Console.Clear();
            Console.WriteLine($"현재 {potionType.ToString()}가 최대입니다. 포션을 사용할 수 없습니다.");
            Console.WriteLine("포션 선택 화면으로 돌아가시려면 아무 키나 입력하세요.");
            Console.ReadLine();
        }
        public void NoPotion()
        {
            Console.Clear();
            Console.WriteLine("포션이 없습니다.");
            Console.WriteLine("포션 선택 화면으로 돌아가시려면 아무 키나 입력하세요.");
            Console.ReadLine();
        }
        public void ShowNPC() // 여관 메뉴
        {

            Console.Write ($"""

               ┌ [여관]──────────────────────────────────────┐
               │                                             │
               │  여관으로 왔습니다.                         │    
               │  퀘스트를 관리하거나 휴식을 할 수 있습니다. │
               │                                             │
               └─────────────────────────────────────────────┘


               1. 퀘스트 관리

               2. 휴식하기


               """);
            Exit();

        }
        public void ShowQuestList(List<Quest> available, List<Quest> locked, bool hasUnclaimedReward)   // 전체 퀘스트 목록 보기
        {
            Console.WriteLine("\n┌ [시작 가능 퀘스트]───────────────────────────────┐");
            Console.WriteLine("│                                                  │");

            if (available.Count == 0)
            {
                Console.WriteLine("│  (없음)                                          │");
                Console.WriteLine("│                                                  │");
                Console.WriteLine("└──────────────────────────────────────────────────┘");
            }
            else
            {
                for (int i = 0; i < available.Count; i++)
                {
                    string print = "";

                    print = $"│  {i + 1}. {available[i].Name}";
                    for (int a = GetStringWidth(print); a < 51; a++)
                    {
                        print += " ";
                    }
                    Console.WriteLine($"{print} │");
                    
                }
                Console.WriteLine("│                                                  │");
                Console.WriteLine("└──────────────────────────────────────────────────┘");
            }

            Console.WriteLine("\n\n┌ [잠긴 퀘스트]────────────────────────────────────┐");
            Console.WriteLine("│                                                  │");

            if (locked.Count == 0)
            {
                Console.WriteLine("│  (없음)                                          │");
            }
            else
            {
                foreach (var quest in locked)
                {
                    string print = "";        
                    print = $"│  - {quest.Name} (요구 레벨 : {quest.RequestLevel})";
                    for (int a = GetStringWidth(print); a < 51; a++)
                    {
                        print += " ";
                    }
                    Console.WriteLine($"{print} │");
                }
            }
            Console.WriteLine("│                                                  │");
            Console.WriteLine("└──────────────────────────────────────────────────┘");

            // 퀘스트 완료 알림 문구 표시
            string notice = hasUnclaimedReward ? " (알림 : 완료한 퀘스트가 있습니다!)" : "";
            Console.Write($"""

            {available.Count + 1}. 내 퀘스트 보기{notice}


            """);
            Exit();
        }
        public void ShowQuestInfo(Quest quest)  // 선택한 퀘스트의 정보 보기
        {
            Console.WriteLine();
            Console.WriteLine("┌ [퀘스트 정보]─────────────────────────────────────┐");
            Console.WriteLine("│                                                   │");

            string print = "";
            print = $"│  {quest.Name} 퀘스트.";
            for (int a = GetStringWidth(print); a < 52; a++)
            {
                print += " ";
            }
            Console.WriteLine($"{print} │");

            String print2 = "";
            print2 = $"│  {quest.Text} ";
            for (int a = GetStringWidth(print2); a < 52; a++)
            {
                print2 += " ";
            }
            Console.WriteLine($"{print2} │ ");

            Console.WriteLine("│                                                   │");
            String print3 = "";
            print3 = $"│  처치할 몬스터: {quest.Target} {quest.TargetCount} 마리 ";
            for (int a = GetStringWidth(print3); a < 52; a++)
            {
                print3 += " ";
            }
            Console.WriteLine($"{print3} │ ");

            Console.WriteLine("│                                                   │");
            Console.WriteLine("├ [보상]────────────────────────────────────────────┤");
            Console.WriteLine("│                                                   │");

            String print4 = "";
            print4 = $"│  - 골드 : {quest.Gold} G";
            for (int a = GetStringWidth(print4); a < 52; a++)
            {
                print4 += " ";
            }
            Console.WriteLine($"{print4} │ ");


            if (quest.Reward.Count > 0)
            {
                Console.WriteLine("│                                                   │");


                foreach (var item in quest.Reward)
                {
                    // Console.Write($"│  - 아이템 : {item.Text} ");

                    String print5 = "";
                    print5 = $"│  - 아이템 : {item.Text}";
                    for (int a = GetStringWidth(print5); a < 52; a++)
                    {
                        print5 += " ";
                    }
                    Console.WriteLine($"{print5} │ ");

                }
            }
            Console.WriteLine("│                                                   │");
            Console.WriteLine("└───────────────────────────────────────────────────┘");
            Console.Write($"""


            1. 퀘스트 받기


            """);
            Exit();
        }
        public void ShowAcceptingQuest(string questName)    // 퀘스트 수락 메시지
        {
            string print = "";
            print = $"┌ [{questName}]";
            for (int a = GetStringWidth(print); a < 32; a++)
            {
                print += "─";
            }
            Console.WriteLine($"{print}┐");
            Console.Write($"""
               │                              │
               │  퀘스트를 받았습니다.        │
               │                              │
               └──────────────────────────────┘


               """);
            Exit();
        }
        public void ShowQuestCompleted(Quest quest) // 완료된 퀘스트 선택 시 보이는 퀘스트 완료 창
        {
            string print = "";
            print = $" ┌ [{quest.Name}]";
            for (int a = GetStringWidth(print); a < 50; a++)
            {
                print += "─";
            }
            Console.WriteLine($"{print}┐");

            Console.WriteLine(" │                                               │ ");
            Console.WriteLine(" │  퀘스트를 완료했습니다.                       │");
            Console.WriteLine(" │                                               │ ");
            Console.WriteLine(" ├ [보상]────────────────────────────────────────┤");
            Console.WriteLine(" │                                               │ ");

            string print2 = "";
            print2 = $" │  - 골드 : {quest.Gold} G";
            for (int a = GetStringWidth(print2); a < 50; a++)
            {
                print2 += " ";
            }
            Console.WriteLine($"{print2}│");

            Console.WriteLine(" │                                               │ ");

            if (quest.Reward.Count > 0)
            {
                foreach (var item in quest.Reward)
                {
                    // Console.Write($"{item.Text} ");
                    string print3 = "";
                    print3 = $" │  - 아이템 : {item.Text}";
                    for (int a = GetStringWidth(print3); a < 50; a++)
                    {
                        print3 += " ";
                    }
                    Console.WriteLine($"{print3}│");

                }
                Console.WriteLine(" │                                               │ ");
            }
            Console.WriteLine(" └───────────────────────────────────────────────┘");

            Console.Write($"""


            1. 보상 받기


            """);

            Exit();  
        }
        
        public void ShowReceiveQuestRewards(Quest quest, int playerGold)    // 완료한 퀘스트의 보상을 받는 창
        {
            Console.WriteLine(" ┌ [보상 수령 완료]───────────────────────────┐");
            Console.WriteLine(" │                                            │ ");
            string print = "";
            print = $" │  보유 골드: {playerGold} G";
            for (int a = GetStringWidth(print); a < 46; a++)
            {
                print += " ";
            }
            Console.WriteLine($"{print} │");
            if (quest.Reward.Count > 0)
            {
                Console.WriteLine(" │                                            │ ");
                foreach (var item in quest.Reward)
                {
                    string print2 = "";
                    print2 = $" │  새로운 아이템 : {item.Text}";
                    for (int a = GetStringWidth(print2); a < 46; a++)
                    {
                        print2 += " ";
                    }
                    Console.WriteLine($"{print2} │");
                }
            }
            Console.WriteLine(" │                                            │ ");
            Console.WriteLine(" └────────────────────────────────────────────┘");
            Console.WriteLine();
            Exit();
        }


        public void ShowViewAcceptedQuest(List<Quest> acceptedQuests, bool hasRewardableQuest)  // 내가 진행 중인 퀘스트와 완료한 퀘스트 목록 창 
        {
            Console.WriteLine(" 내가 받은 퀘스트들을 확인하는 창입니다.");
            Console.WriteLine();
            Console.WriteLine("┌ [진행 중인 퀘스트]───────────────────────────────┐");
            Console.WriteLine("│                                                  │");

            var showable = acceptedQuests.Where(q => !q.IsRewarded).ToList();
            var rewarded = acceptedQuests.Where(q => q.IsRewarded).ToList();

            if (showable.Count == 0)
            {
                Console.WriteLine("│  (없음)                                          │");
            }
            else
            {
                for (int i = 0; i < showable.Count; i++)
                {
                    var quest = showable[i];
                    string completeText = quest.IsComplete() ? " [완료]" : "";
                    string print = "";
                    print = $"│  {i + 1}. {quest.Name} ({quest.Count} / {quest.TargetCount}){completeText}";
                    for (int j = GetStringWidth(print); j < 51; j++)
                    {
                        print += " ";
                    }
                    Console.WriteLine($"{print} │");

                }
            }
            Console.WriteLine("│                                                  │");

            Console.WriteLine("└──────────────────────────────────────────────────┘");

            Console.WriteLine("\n\n┌ [완료한 퀘스트]──────────────────────────────────┐");
            Console.WriteLine("│                                                  │");

            if (rewarded.Count == 0)
            {
                Console.WriteLine("│  (없음)                                          │");
            }
            else
            {
                foreach (var q in rewarded)
                {
                    string print = "";
                    print = $"│  {q.Name} 퀘스트";
                    for (int a = GetStringWidth(print); a < 51; a++)
                    {
                        print += " ";
                    }
                    Console.WriteLine($"{print} │");
                    

                }
            }
            Console.WriteLine("│                                                  │");
            Console.WriteLine("└──────────────────────────────────────────────────┘\n");

            if (hasRewardableQuest)
            {
                Console.WriteLine("\n\n(알림 : [완료] 표시가 있는 퀘스트를 선택하여 보상을 받으세요)\n");
            }


            Exit();
        }
        public void ShowRest(Player player) // 휴식하기 안내 창
        {
            Console.WriteLine($"""
               ┌ [휴식하기]──────────────────────────────────────────────────────────┐
               │                                                                     │
               """);
            string print = "";
            print = $"│  500 G 를 소모하여 체력을 회복할 수 있습니다. (보유 골드 : {player.Gold} G)";
            for (int a = GetStringWidth(print); a < 71; a++)
            {
                print += " ";
            }
            Console.WriteLine($"{print}│");
            Console.WriteLine($"""
               │                                                                     │
               └─────────────────────────────────────────────────────────────────────┘

            

               1. 휴식하기


               """);
            Exit();
        }
        public void ShowRestSuccess(Player player)  // 휴식 완료 창
        {
            Console.WriteLine($"""
               ┌ [휴식 완료]─────────────────────────────────────────────────────────┐
               │                                                                     │
               """);
            string print = "";
            print = $"│  체력이 모두 회복되었습니다. (남은 골드 : {player.Gold} G) ";
            for (int a = GetStringWidth(print); a < 71; a++)
            {
                print += " ";
            }
            Console.WriteLine($"{print}│");
            Console.Write($"""
               │                                                                     │
               └─────────────────────────────────────────────────────────────────────┘


               """);
            Exit();

        }

        public void ShowRestFail(Player player)  // 휴식 실패 창
        {
            Console.WriteLine($"""
               ┌ [휴식 실패]─────────────────────────────────────────────────────────┐
               │                                                                     │  
               """);
            string print = "";
            print = $"│  골드가 부족합니다. (현재 골드 : {player.Gold} G) ";
            for (int a = GetStringWidth(print); a < 70; a++)
            {
                print += " ";
            }
            Console.WriteLine($"{print} │");
            Console.WriteLine($"""
               │                                                                     │
               └─────────────────────────────────────────────────────────────────────┘

               """);
            Exit();
        }

        public void ErrorMessage()
        {
            Console.WriteLine("잘못된 입력입니다 ");
            Exit();
        }
        public void Exit()
        {
            Console.Write($"""
               0. 나가기
              
               원하시는 행동을 입력해주세요.
               >> 
               """);
        }

        int GetStringWidth(string str)
        {
            int width = 0;
            foreach (char c in str)
            {
                // 한글, 박스문자, 기타 특수문자 2칸, 나머지는 1칸
                if ((c >= 0xAC00 && c <= 0xD7A3) || (c >= 0x2500 && c <= 0x257F))
                    width += 2;
                else
                    width += 1;
            }
            return width;
        }
    }

}

