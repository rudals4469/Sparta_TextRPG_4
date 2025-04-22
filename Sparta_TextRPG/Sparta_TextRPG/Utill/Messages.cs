using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
        public void ShowStart()
        {
            Console.Write(
                """     
                스파르타 마을에 오신 여러분 환영합니다.
                이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

                1. 상태 보기
                2. 인벤토리
                3. 상점
                4. 던전입장
                5. 휴식하기
                6. 게임종료
                원하시는 행동을 입력해주세요.
                >>
                """);
        }

        public void ShowStartSetName()
        {

            Console.Write($"""
                스파르타 던전에 오신여러분 환영합니다.
                원하시는 이름을 설정해주세요

                >>
                """);
        }
        public void ShowStartChackName(string Name)
        {
            Console.Write($"""
                스파르타 던전에 오신여러분 환영합니다.
                원하시는 이름을 설정해주세요
                {Name}

                입력하신 이름은 {Name}입니다.

                1.저장
                2.취소
                
                원하시는 행동을 입력해주세요
                >>
                """);
        }
        public void ShowStartSetClass()
        {

            Console.Write($"""
                스파르타 던전에 오신여러분 환영합니다.
                원하시는 직업을 설정해주세요

                1.{ClassName.전사.ToString()}
                2.{ClassName.마법사.ToString()}
                3.{ClassName.궁수.ToString()}
                4.{ClassName.도적.ToString()}
                5.{ClassName.해적.ToString()}

                원하시는 행동을 입력해주세요
                >>
                """);

        }

        //
        public void ShowBattelStart(List<Monster> monsters, Player player)
        {
            foreach (var item in monsters)            {

                Console.WriteLine($"Lv.{item.Level} {item.MonsterName.ToString()} HP {item.NowHP}");

            }
            Console.Write(
               $"""
               [내정보]
               Lv.{player.Level} {player.Name} ({player.Class.ToString()})
               HP {player.NowHP}/{player.MaxHP}
                
               1.공격

               원하시는 행동을 입력해주세요.
               >>
               """
                );

        }

        public void ShowBattelAttackPhase(List<Monster> monsters, Player player)
        {
            int count = 0;
            foreach (var item in monsters)
            {
                count++;

                if (item.IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write($"{count} Lv.{item.Level} {item.MonsterName.ToString()} Dead");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{count} Lv.{item.Level} {item.MonsterName.ToString()} HP:{item.NowHP}");
                }

            }
            Console.Write(
               $"""
               [내정보]
               Lv.{player.Level} {player.Name} ({player.Class.ToString()})
               HP {player.NowHP}/{player.MaxHP}
                
               0.취소

               대상을 선택해주세요
               >>
               """
             );
        }
        public void ShowBattelAttackMonster(Monster monster, Player player, Skill PlayerSkill)
        {
            Console.Write(
               $"""
               player{player.Name} 의 공격!
               Lv.{monster.Level} {monster.MonsterName.ToString()}을(를) 맞췄습니다. [데미지 : {PlayerSkill.Damage}]

               {monster.Level} {monster.MonsterName.ToString()}
               """);

            if ((monster.NowHP - PlayerSkill.Damage) < 0)
            {
                Console.WriteLine($"HP {monster.NowHP} -> Dead");
            }
            else
            {
                Console.WriteLine($"HP {monster.NowHP} -> {monster.NowHP - PlayerSkill.Damage}");
                
            }

            Console.Write(
                $"""

                0. 다음
               """);

        }
        public void ShowBattelMonsterPhase(Monster monster, Player player, Skill MonsterSkill)
        {
            Console.Write(
               $"""
               Battle!!

               Lv.{monster.Level} {monster.MonsterName.ToString()} 의 공격!
               {player.Name} 을(를) 맞췄습니다.  [데미지 : {MonsterSkill.Damage}]

               Lv.{player.Level} {player.Name}
               HP {player.NowHP} -> {player.NowHP- MonsterSkill.Damage};

               0. 다음

               대상을 선택해주세요.
               >>
               """);
        }
        public void ShowBattlePlayerWin(List<Monster> monsters,int HP ,Player player)
        {
            Console.Write(
               $"""
               Battle!! - Result

               Victory

               던전에서 몬스터 {monsters.Count}마리를 잡았습니다.

               Lv.{player.Level} {player.Name}
               HP {HP} -> {player.NowHP}

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
               HP HP -> {player.NowHP}

               0. 다음
               >>
               """);
        }

        public void ShowStatus(Player player)         //$""" 사용해보려 하였으나 익숙치 않아 익숙한 것으로 진행
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine();                                       //줄 바꿈 처리
            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine($"{player.Name} ( {player.Class} )");
            Console.WriteLine($"공격력 : {player.AttackPoint}");
            Console.WriteLine($"방어력 : {player.ArmorPoint}");
            Console.WriteLine($"체  력 : {player.NowHP}/{player.MaxHP}");                //원본 가이드에서 띄어쓰기 되어있음
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();                                      //줄 바꿈 처리

            Console.WriteLine("장착 중인 아이템:");                     // 상태창에서 바로 장착중인 아이템이 보여지게 수정
            if (player.Weapon != null)
                Console.WriteLine($"- 무기: {player.Weapon.Name}");    // 무기 장착 칸
            if (player.Armor != null)
                Console.WriteLine($"- 방어구: {player.Armor.Name}");   // 방어구 장착 칸
            if (player.Shiled != null)
                Console.WriteLine($"- 방패: {player.Shiled.Name}");   // 방패 장착 칸
            if (player.Potion != null)
                Console.WriteLine($"- 포션: {player.Potion.Name}");   // 포션 장착 칸

           
            Console.WriteLine();                                      //줄 바꿈 처리
            Console.WriteLine("인벤토리:");                            // 상태창에서 바로 인벤토리가 보여지게 설정
                                                                     // 상태창에 너무 많은 정보가 보일 것 같아서 인벤토리 안으로 넣을 예정입니다 (수정예정이며 현재 임시 작성)
            Console.WriteLine("[무기]");                              
            foreach (var weapon in player.Inventory.Weapon)
            {
                Console.WriteLine($" - {weapon.Name}");
            }

            Console.WriteLine("[방어구]");
            foreach (var armor in player.Inventory.Armors)
            {
                Console.WriteLine($" - {armor.Name}");
            }

            Console.WriteLine("[방패]");
            foreach (var shield in player.Inventory.Shild)
            {
                Console.WriteLine($" - {shield.Name}");
            }

            Console.WriteLine("[포션]");
            foreach (var potion in player.Inventory.Potions)
            {
                Console.WriteLine($" - {potion.Name}");
            }

            Console.WriteLine("\n0. 나가기");
            while (Console.ReadLine() != "0")
            {
                Console.WriteLine("0을 입력해주세요.\n>> ");
            }
        }


        public void ShowInventory(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                int totalItemCount = player.Inventory.Weapon.Count
                                   + player.Inventory.Armors.Count
                                   + player.Inventory.Shild.Count
                                   + player.Inventory.Potions.Count;

                if (totalItemCount == 0)
                {
                    Console.WriteLine("아이템이 없습니다.");
                }
                else
                {
                    Console.WriteLine("[무기]");
                    foreach (var weapon in player.Inventory.Weapon)
                    {
                        string prefix = weapon.IsEquipped ? "[E]" : "";
                        Console.WriteLine($"- {prefix}{weapon.Name} | +{weapon.AttackPoint} | {weapon.Text}");
                    }

                    Console.WriteLine("\n[방어구]");
                    foreach (var armor in player.Inventory.Armors)
                    {
                        string prefix = armor.IsEquipped ? "[E]" : "";
                        Console.WriteLine($"- {prefix}{armor.Name} | +{armor.ArmorPoint} | {armor.Text}");
                    }

                    Console.WriteLine("\n[방패]");
                    foreach (var shield in player.Inventory.Shild)
                    {
                        string prefix = shield.IsEquipped ? "[E]" : "";
                        Console.WriteLine($"- {prefix}{shield.Name} | +{shield.ArmorPoint} +{shield.AttackPoint} | {shield.Text}");
                    }

                    Console.WriteLine("\n[포션]");
                    foreach (var potion in player.Inventory.Potions)
                    {
                        Console.WriteLine($"- {potion.Name} | +{potion.HealPoint} | {potion.Text}");
                    }
                }

                Console.WriteLine("\n1. 장착 관리");
                Console.WriteLine("0. 나가기");
                Console.Write("\n원하시는 행동을 입력해주세요. >> ");
                string input = Console.ReadLine();

                if (input == "0") break;
                else if (input == "1") ManageEquipment(player); 
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadKey();
                }
            }
        }





        public void ErrorMessage()
        {
            Console.WriteLine("잘못된 입력입니다 ");
        }
        
        public void ShowNPC()
        {

            Console.Write($"""
               NPC에게 왔습니다. 
               1. 퀘스트 받기
               2. 휴식하기

               원하시는 행동을 입력해주세요. 
               >>
               """);
               
        }

        public void ShowRest(Player player)
        {
            Console.Write($"""
               500 G 를 소모하여 체력을 회복할 수 있습니다. (보유 골드 : {0} G)

               1. 휴식하기
               2. 나가기

               원하시는 행동을 입력해주세요. 
               >> 
               """, player.Gold);
        }
        public void ShowDungoun()
        {
            Console.Write($$"""
               던전입장
               이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다. 
               
               1. {0} 던전     |      던전 레벨 : {1}  
               2. {2} 던전     |      던전 레벨 : {3}
               3. {4} 던전     |      던전 레벨 : {5}

               0. 나가기 

               원하시는 행동을 입력해주세요. 
               >>
               """, Dungoun.Name, Dungoun.Level);
        }

        public void ShowHealing()
        {
            Console.Write($"""
               [휴식 완료] 체력이 모두 회복되었습니다. (골드 -500)

               0.돌아가기

               >>
               """);

        }

        public void ShowNoHealing()
        {
            Console.Write($"""
               [실패] 골드가 부족합니다.

               0.돌아가기

               >>
               """);
        }
    }

}

