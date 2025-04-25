
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
        public void ShowStart()
        {
            Console.Write(
                """     
                메이플 월드에 오신 여러분 환영합니다.
                이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

                1.상태 보기
                2.상점
                3.던전입장
                4.여관으로 가기
                5.게임종료

                원하시는 행동을 입력해주세요.
                >> 
                """);
        }
        public void ShowStartSetName()
        {

            Console.Write($"""
                메이플 월드에 오신여러분 환영합니다.
                원하시는 이름을 설정해주세요

                >> 
                """);
        }
        public void ShowStartChackName(string Name)
        {
            Console.Write($"""
                메이플 월드에 오신여러분 환영합니다.
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
                메이플 월드에 오신여러분 환영합니다.
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
        public void ShowStatus(Player player)         //$""" 사용해보려 하였으나 익숙치 않아 익숙한 것으로 진행
        {
            Console.WriteLine("[상태 보기]");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();                                       //줄 바꿈 처리
            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine($"{player.Name} ({player.Class})");
            Console.WriteLine($"{"공격력",-5}: {player.AttackPoint}");
            Console.WriteLine($"{"방어력",-5}: {player.ArmorPoint}");
            Console.WriteLine($"{"체  력",-6}: {player.NowHP} / {player.MaxHP}");
            Console.WriteLine($"{"경험치",-5}: {player.Exp} / {player.MaxExp}");
            Console.WriteLine($"{"Gold",-8}: {player.Gold} Meso");
            Console.WriteLine();                                      //줄 바꿈 처리

            Console.WriteLine("[인벤토리]");                             //player 인벤토리로 받을 수 있게 처리
                                                                     //인벤토리 출력은 4단계를 거쳐서 작성해야함
                                                                     //foreach (var item in player.Inventory)                    //배열 리스트 순차적으로 꺼내서 처리(var 변수 타입 결정 player인벤토리 안에 있는 아이템 전부 item처리)
                                                                     //Console.WriteLine($" - {item.Name} x{item.Quantity}"); //아이템 이름과 수량


            Console.WriteLine("장착 중인 아이템:");                     // 상태창에서 바로 장착중인 아이템이 보여지게 수정
            Console.Write($"- {"무기",-4} :");
            if (player.Weapon != null)
                Console.WriteLine($" {player.Weapon.Text}"); // 무기 장착 칸
            else Console.WriteLine(); // 아니여도 줄 바꿈
            Console.Write($"- {"방어구",-3} :");
            if (player.Armor != null)
                Console.WriteLine($" {player.Armor.Text}");   // 방어구 장착 칸
            else Console.WriteLine();
            Console.Write($"- {"방패",-4} :");
            if (player.Shield != null)
                Console.WriteLine($" {player.Shield.Text}");   // 방패 장착 칸
            else Console.WriteLine();

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

            if (totalItemCount == 0)
            {
                Console.WriteLine("아이템이 없습니다.");
            }
            else
            {
                Console.WriteLine("\n[무기]\n");
                foreach (var weapon in player.Inventory.Weapon)
                {
                    string prefix = weapon.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {prefix}{weapon.Text} | {weapon.Price,-5} Meso | 공격력 + {weapon.AttackPoint} ");
                }

                Console.WriteLine("\n[방어구]\n");
                foreach (var armor in player.Inventory.Armors)
                {
                    string prefix = armor.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {prefix}{armor.Text} | {armor.Price,-5} Meso | 방어력 + {armor.ArmorPoint}");
                }

                Console.WriteLine("\n[방패]\n");
                foreach (var shield in player.Inventory.Shild)
                {
                    string prefix = shield.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {prefix}{shield.Text} | {shield.Price,-5} Meso | 공격력 + {shield.ArmorPoint} 방어력 + {shield.AttackPoint}");
                }

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
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");


            int totalItemCount = player.Inventory.Weapon.Count
                                   + player.Inventory.Armors.Count
                                   + player.Inventory.Shild.Count
                                   + player.Inventory.Potions.Count;

            int Count = 1;


            if (totalItemCount == 0)
            {
                Console.WriteLine("아이템이 없습니다.");
            }
            else
            {
                Console.WriteLine("\n[무기]\n");

                foreach (var weapon in player.Inventory.Weapon)
                {
                    string prefix = weapon.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {Count,-2} {prefix}{weapon.Text} | {weapon.Price,-5} Meso | 공격력 + {weapon.AttackPoint} ");
                    Count++;
                }

                Console.WriteLine("\n[방어구]\n");
                foreach (var armor in player.Inventory.Armors)
                {
                    string prefix = armor.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {Count,-2} {prefix}{armor.Text} | {armor.Price,-5} Meso | 방어력 + {armor.ArmorPoint}");
                    Count++;
                }

                Console.WriteLine("\n[방패]\n");
                foreach (var shield in player.Inventory.Shild)
                {
                    string prefix = shield.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {Count,-2} {prefix}{shield.Text} | {shield.Price,-5} Meso | 공격력 + {shield.ArmorPoint} 방어력 + {shield.AttackPoint}");
                    Count++;
                }

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



            Console.WriteLine("\n[무기]\n");
            foreach (var weapon in shop.Inventory.Weapon)
            {
                Console.WriteLine($"- {Count,-2} {weapon.Text} | {weapon.Price,-5} Meso | 공격력 + {weapon.AttackPoint} ");
                Count++;
            }

            Console.WriteLine("\n[방어구]\n");
            foreach (var armor in shop.Inventory.Armors)
            {

                Console.WriteLine($"- {Count,-2} {armor.Text} | {armor.Price,-5} Meso | 방어력 + {armor.ArmorPoint}");
                Count++;
            }

            Console.WriteLine("\n[방패]\n");
            foreach (var shield in shop.Inventory.Shild)
            {

                Console.WriteLine($"- {Count,-2} {shield.Text} | {shield.Price,-5} Meso | 공격력 + {shield.ArmorPoint} 방어력 + {shield.AttackPoint}");
                Count++;
            }

            Console.WriteLine("\n[포션]\n");
            foreach (var potion in shop.Inventory.Potions)
            {
                Console.WriteLine($"- {Count,-2} {potion.Text} | {potion.Price,-5} Meso | {potion.HealPoint} 회복 ");
                Count++;
            }

            Console.Write("""
                --------------------------------------------------------------
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
            Console.WriteLine("\n[무기]\n");
            foreach (var weapon in shop.Inventory.Weapon)
            {
                Console.WriteLine($"- {Count,-2} {weapon.Text} | {weapon.Price,-5} Meso | 공격력 + {weapon.AttackPoint} ");
                Count++;
            }

            Console.WriteLine("\n[방어구]\n");
            foreach (var armor in shop.Inventory.Armors)
            {
                Console.WriteLine($"- {Count,-2} {armor.Text} | {armor.Price,-5} Meso | 방어력 + {armor.ArmorPoint}");
                Count++;
            }

            Console.WriteLine("\n[방패]\n");
            foreach (var shield in shop.Inventory.Shild)
            {

                Console.WriteLine($"- {Count,-2} {shield.Text} | {shield.Price,-5} Meso | 공격력 + {shield.ArmorPoint} 방어력 + {shield.AttackPoint}");
                Count++;
            }


            Console.WriteLine("\n[포션]\n");
            foreach (var potion in shop.Inventory.Potions)
            {
                Console.WriteLine($"- {Count,-2} {potion.Text} | {potion.Price,-5} Meso | {potion.HealPoint} 회복 ");
                Count++;
            }

            Console.Write("""
                --------------------------------------------------------------

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



            Console.WriteLine("\n[무기]\n");
            foreach (var weapon in player.Inventory.Weapon)
            {
                Console.WriteLine($"- {Count,-2} {weapon.Text} | {weapon.Price,-5} Meso | 공격력 + {weapon.AttackPoint} ");
                Count++;
            }

            Console.WriteLine("\n[방어구]\n");
            foreach (var armor in player.Inventory.Armors)
            {

                Console.WriteLine($"- {Count,-2} {armor.Text} | {armor.Price,-5} Meso | 방어력 + {armor.ArmorPoint}");
                Count++;
            }

            Console.WriteLine("\n[방패]\n");
            foreach (var shield in player.Inventory.Shild)
            {

                Console.WriteLine($"- {Count,-2} {shield.Text} | {shield.Price,-5} Meso | 공격력 + {shield.ArmorPoint} 방어력 + {shield.AttackPoint}");
                Count++;
            }

            Console.WriteLine("\n[포션]\n");

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
            //    Console.WriteLine($"- {Count,-2} {potion.Text} | {potion.Price,-5} Meso | {potion.HealPoint} 회복 ");
            //    Count++;
            //}
            var potionssearch = player.Inventory.Potions.OrderBy(p => p.PotionType);

            foreach (var potion in potionssearch)
            {
                Console.WriteLine($"- {Count,-2} {potion.Text} | {potion.Price,-5} Meso | {potion.HealPoint} 회복 ");
                Count++;
            }


            Console.Write("""
                --------------------------------------------------------------
                0. 나가기

                번호를 눌러 원하는 아이템을 팔거나 원하시는 행동을 입력해주세요.
                >> 
                """);
        }
        public void NotEnoughMoney()
        {
            Console.WriteLine("[실패] 골드가 부족합니다. 아무 숫자를 눌러 상점으로 돌아가세요.");
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
        public void ShowDungoun(List<Dungeon> dungouns)
        {
            Console.Write($"""
               던전입장
               이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다. 
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
            Console.WriteLine("던전 선택");
            foreach (var item in dungouns)
            {
                Console.Write($"{++count,2}. {item.Name} | 권장 레벨 : {item.Level} 등장 몬스터 :");
                foreach (var item1 in item.baseMonsters)
                {
                    if(item1.Level >= 10 ) Console.Write($" ? |");
                    else Console.Write($" {item1.Name} |");
                }
                Console.WriteLine("");
            }
            Console.Write($"""

                {++count}. 상태 보기
                {++count}. 회복 아이템
                """);
            Exit();
        }
        public void printMonster(List<Monster> monsters)
        {
            int count = 0;
            foreach (var item in monsters)
            {
                count++;

                if (item.IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{count} Lv.{item.Level} {item.MonsterName.ToString()} Dead");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{count} Lv.{item.Level} {item.MonsterName.ToString()} HP:{item.NowHP}");
                }

            }
        }
        public void ShowBattleStart(List<Monster> monsters, Player player)
        {

            printMonster(monsters);

            Console.Write(
               $"""

               [내정보]
               Lv.{player.Level} {player.Name} ({player.Class.ToString()})
               HP {player.NowHP}/{player.MaxHP}
               Mp {player.NowMP}/{player.MaxMP} 

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

               [내정보]
               Lv.{player.Level} {player.Name} ({player.Class.ToString()})
               HP {player.NowHP}/{player.MaxHP}
               Mp {player.NowMP}/{player.MaxMP} 
               
               """);
            int count = 0;
            Console.WriteLine("No.     이름       | 마나 |     쿨타임    |  설명");
            foreach (var item in player.SkillList)
            {
                Console.WriteLine($"{++count,-3} {item.Name,-14} | {item.Mana,4} | {item.NowCoolTime,6}/{item.CoolTime,6} | {item.Text}");
            }
            Console.Write("""

                원하시는 행동을 입력해주세요.
                >>
                """);
        }
        public void CoolTimeError()
        {
            Console.Write("[스킬 사용 불가] 쿨타임 중이므로 다른 스킬을 사용해주세요.");
            //Thread.Sleep(3000);
        }
        public void ShowBattleAttackPhase(List<Monster> monsters, Player player)
        {
            printMonster(monsters);

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
        public void ShowBattleAttackMonster(Monster monster,int monsterbeforHP, Player player, int Damage)
        {
            if (Damage > 0)
            {
                Console.Write(
                $"""
               player{player.Name} 의 공격!
               Lv.{monster.Level} {monster.MonsterName.ToString()}을(를) 맞췄습니다. [데미지 : {Damage}]

               {monster.Level} {monster.MonsterName.ToString()}
               """);

                if (monster.IsDead)
                {
                    Console.WriteLine($"HP {monsterbeforHP} -> Dead");
                }
                else
                {
                    Console.WriteLine($"HP {monsterbeforHP} -> {monsterbeforHP - Damage}");

                }
            }
            else
            {
                Random random = new Random();
                int n = random.Next(0, 100);
                if(n % 5 == 0) Console.Write($"{monster.Name}이(가) {player.Name}님의 공격을 \"훗\" 하고 피함");
                else
                {
                    Console.WriteLine($"{monster.Name}가 슉 슈슉 슉 ");
                    Console.WriteLine($"{player.Name}님의 공격이 빘나갔습니다");
                }
                //회피 문구 추가하기
            }


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
               Battle!!

               """);
        }
        public void ShowBattleMonsterHitPhase(Monster monster,int beforHp ,Player player, int Damage)
        {
            if (Damage > 0)
            {
                Console.WriteLine(
              $"""
               Lv. {monster.Level} {monster.MonsterName.ToString()} 의 공격!
               {player.Name} 을(를) 맞췄습니다.  [데미지 : {Damage}]

               Lv.{player.Level} {player.Name}
               HP {beforHp} -> {player.NowHP};

               """);
            }
            else
            {
                Random random = new Random();
                int n = random.Next(0, 100);
                if(n % 5 == 0) Console.WriteLine($"{player.Name}이(가) {monster.Name}님의 공격을 \"훗\" 하고 피함");
                else
                {
                    Console.WriteLine($"{player.Name}가 슉 슈슉 슉 ");
                    Console.WriteLine($"{monster.Name}의 공격이 빘나갔습니다");
                }
            }
        }
        public void ShowBattleMonsterEndPhase()
        {
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
                [소유 포션]
                1. HP 포션 | +100HP ({HpPotionCount}개)
                2. MP 포션 | +100MP ({MpPotionCount}개)
                3. 엘릭서  | +500HP ({AlixirCount}개)

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
        public void ShowNPC()
        {

            Console.Write($"""
               여관으로 왔습니다. 
               퀘스트를 관리하거나 휴식을 할 수 있습니다. 


               1. 퀘스트 관리

               2. 휴식하기

               """);
            Exit();

        }
        public void ShowQuestList(List<Quest> available, List<Quest> locked, bool hasUnclaimedReward)
        {
            Console.WriteLine("[시작 가능 퀘스트]\n");

            if (available.Count == 0)
            {
                Console.WriteLine("(없음)");
            }
            else
            {
                for (int i = 0; i < available.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {available[i].Name}");
                }
            }

            Console.WriteLine("\n\n[잠긴 퀘스트]\n");

            if (locked.Count == 0)
            {
                Console.WriteLine("(없음)");
            }
            else
            {
                foreach (var quest in locked)
                {
                    Console.WriteLine($"- {quest.Name} (요구 레벨 : {quest.RequestLevel})\n ");
                }
            }

            // 퀘스트 완료 알림 문구 표시
            string notice = hasUnclaimedReward ? " (알림 : 완료한 퀘스트가 있습니다!)" : "";
            Console.Write($"""

            {available.Count + 1}. 내 퀘스트 보기{notice}

            """);
            Exit();
        }
        public void ShowQuestInfo(Quest quest)
        {
            Console.WriteLine("[퀘스트 정보]\n");

            Console.WriteLine($"{quest.Name} 퀘스트");
            Console.WriteLine(quest.Text);
            Console.WriteLine($"\n처치할 몬스터: {quest.Target} {quest.TargetCount}마리");

            Console.WriteLine("\n\n[보상]");
            Console.WriteLine($"- 골드 : {quest.Gold} G");

            if (quest.Reward.Count > 0)
            {
                Console.Write("- 아이템 : ");
                foreach (var item in quest.Reward)
                {
                    Console.Write($"{item.Text} ");
                }
                Console.WriteLine();
            }

            Console.Write($"""


            1. 퀘스트 받기

            """);
            Exit();
        }
        public void ShowAcceptingQuest(string questName)    // 퀘스트 수락 메시지
        {
            Console.Write($"""
               [{questName}] 퀘스트를 받았습니다. 

               """);
            Exit();
        }
        public void ShowQuestCompleted(Quest quest)
        {
            Console.WriteLine($"[{quest.Name}] 퀘스트를 완료했습니다.\n");

            Console.WriteLine($"보상: {quest.Gold} G");
        }
        public void ShowViewAcceptedQuest(List<Quest> acceptedQuests)
        {
            Console.WriteLine("진행 중인 퀘스트 목록");

            var inProgress = acceptedQuests.Where(q => !q.IsComplete()).ToList();
            var completed = acceptedQuests.Where(q => q.IsComplete()).ToList();

            for (int i = 0; i < inProgress.Count; i++)
            {
                var quest = inProgress[i];  // ← 여기에서 quest 변수를 정의해주는 게 핵심이야

                Console.WriteLine($"{i + 1}. {quest.Name} ({quest.Count} / {quest.TargetCount})");

                if (quest.Reward.Count > 0)
                {
                    Console.Write(" + 아이템: ");
                    foreach (var item in quest.Reward)
                    {
                        Console.Write($"{item.Text} ");
                    }
                    Console.WriteLine(); // 줄 바꿈
                }
            }


            Console.Write($"""

            1. 보상 받기 

            """);
            Exit();
        }

        public void ShowReceiveQuestRewards(Quest quest, int playerGold)
        {
            Console.WriteLine("[보상 수령 완료]");

            Console.WriteLine($"\n현재 보유 골드: {playerGold} G");
            Console.WriteLine("[보상]");
            Console.WriteLine($"- 골드 : {quest.Gold} G");

            if (quest.Reward.Count > 0)
            {
                Console.Write("- 아이템 : ");
                foreach (var item in quest.Reward)
                {
                    Console.Write($"{item.Text} ");
                }
                Console.WriteLine();
            }
            Exit();
        }





        public void ShowViewAcceptedQuest(List<Quest> acceptedQuests, bool hasRewardableQuest)
        {
            if (hasRewardableQuest)
            {
                Console.WriteLine("[진행 중인 퀘스트] (알림 : [완료] 표시가 있는 퀘스트를 선택하여 보상을 받으세요)");
            }
            else
            {
                Console.WriteLine("[진행 중인 퀘스트]");
            }

            var showable = acceptedQuests.Where(q => !q.IsRewarded).ToList();
            var rewarded = acceptedQuests.Where(q => q.IsRewarded).ToList();

            if (showable.Count == 0)
            {
                Console.WriteLine("\n(없음)\n");
            }
            else
            {
                for (int i = 0; i < showable.Count; i++)
                {
                    var quest = showable[i];
                    string completeText = quest.IsComplete() ? " [완료]" : "";
                    Console.WriteLine($"\n{i + 1}. {quest.Name} ({quest.Count} / {quest.TargetCount}){completeText}");

                }
            }

            Console.WriteLine("\n\n[완료한 퀘스트]");

            if (rewarded.Count == 0)
            {
                Console.WriteLine("\n(없음)\n");
            }
            else
            {
                foreach (var q in rewarded)
                {
                    Console.WriteLine($"\n- {q.Name} 퀘스트");
                }
            }

            // 보상 받을 퀘스트가 있으면 안내 메시지 출력
            if (hasRewardableQuest)
            {
                Console.WriteLine("\n\n(알림 : [완료] 표시가 있는 퀘스트를 선택하여 보상을 받으세요)");
            }
            Exit();
        }






        public void ShowRest(Player player)
        {
            Console.Write($"""
               500 G 를 소모하여 체력을 회복할 수 있습니다. (보유 골드 : {player.Gold} G)

               1. 휴식하기

               """);
            Exit();
        }
        public void ShowRestSuccess(Player player)
        {
            Console.Write($"""
               [휴식 완료] 체력이 모두 회복되었습니다. (남은 골드 : {player.Gold} G)

               """);
            Exit();

        }
        public void ShowRestFail()
        {
            Console.Write($"""
               [실패] 골드가 부족합니다.
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
    }

}

