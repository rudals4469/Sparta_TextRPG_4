
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
                메이플 월드에 오신 여러분 환영합니다.
                이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

                1. 상태 보기
                2. 상점
                3. 던전입장
                4. 여관으로 가기(NPC)
                5. 게임종료

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
        //

        public void ShowDungeonSelection(List<Dungeon> dungouns)
        {
            int count = 0;
            Console.WriteLine("던전 선택");
            foreach (var item in dungouns)
            {
                Console.Write($"{++count}. {item.Name} | 권장 레벨 : {item.Level} 등장 몬스터 :");
                foreach (var item1 in item.monsters)
                {
                    Console.Write($" {item1.Name} |");
                }
                Console.WriteLine("");
            }
            Console.Write($"""

                {++count}. 상태 보기
                {++count}. 회복 아이템
                입장할 던전을 선택해 주세요
                >>
                """);
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
            foreach (var item in player.SkillList)
            {
                Console.WriteLine($"{++count} {item.Name} | {item.Text}");
            }
            Console.Write("""

                원하시는 행동을 입력해주세요.
                >>
                """);
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
        public void ShowBattleAttackMonster(Monster monster, Player player, int Damage)
        {
            if (Damage > 0)
            {
                Console.Write(
                $"""
               player{player.Name} 의 공격!
               Lv.{monster.Level} {monster.MonsterName.ToString()}을(를) 맞췄습니다. [데미지 : {Damage}]

               {monster.Level} {monster.MonsterName.ToString()}
               """);

                if ((monster.NowHP - Damage) < 0)
                {
                    Console.WriteLine($"HP {monster.NowHP} -> Dead");
                }
                else
                {
                    Console.WriteLine($"HP {monster.NowHP} -> {monster.NowHP - Damage}");

                }
            }
            else
            {
                Console.Write($"{monster.Name}이 \"훗\" 하고 피함");
                //회피 문구 추가하기
            }


            Console.Write(
                $"""
                 

                0. 다음
               
               >>
               """);

        }
        public void ShowBattleMonsterPhase(Monster monster, Player player, Skill MonsterSkill)
        {
            Console.Write(
               $"""
               Battle!!

               Lv.{monster.Level} {monster.MonsterName.ToString()} 의 공격!
               {player.Name} 을(를) 맞췄습니다.  [데미지 : {MonsterSkill.Damage}]

               Lv.{player.Level} {player.Name}
               HP {player.NowHP} -> {player.NowHP - MonsterSkill.Damage};

               0. 다음

               대상을 선택해주세요.
               >>
               """);
        }
        public void ShowBattlePlayerWin(List<Monster> monsters, int HP, Player player)
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
            Console.WriteLine("[상태 보기]");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();                                       //줄 바꿈 처리
            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine($"{player.Name} ( {player.Class} )");
            Console.WriteLine($"{"공격력",-5}: {player.AttackPoint}");
            Console.WriteLine($"{"방어력",-5}: {player.ArmorPoint}");
            Console.WriteLine($"{"체  력",-6}: {player.NowHP}/{player.MaxHP}");                //원본 가이드에서 띄어쓰기 되어있음
            Console.WriteLine($"{"Gold",-8}: {player.Gold} G");
            Console.WriteLine();                                      //줄 바꿈 처리

            Console.WriteLine("[인벤토리]");                             //player 인벤토리로 받을 수 있게 처리
                                                                   //인벤토리 출력은 4단계를 거쳐서 작성해야함
                                                                   //foreach (var item in player.Inventory)                    //배열 리스트 순차적으로 꺼내서 처리(var 변수 타입 결정 player인벤토리 안에 있는 아이템 전부 item처리)
                                                                   //Console.WriteLine($" - {item.Name} x{item.Quantity}"); //아이템 이름과 수량


            Console.WriteLine("장착 중인 아이템:");                     // 상태창에서 바로 장착중인 아이템이 보여지게 수정
            Console.Write($"- {"무기",-4} :");
            if (player.Weapon != null)
                Console.WriteLine($" {player.Weapon.Name}"); // 무기 장착 칸
            else Console.WriteLine(); // 아니여도 줄 바꿈
            Console.Write($"- {"방어구",-3} :");
            if (player.Armor != null)
                Console.WriteLine($" {player.Armor.Name}");   // 방어구 장착 칸
            else Console.WriteLine();
            Console.Write($"- {"방패",-4} :");
            if (player.Shield != null)
                Console.WriteLine($" {player.Shield.Name}");   // 방패 장착 칸
            else Console.WriteLine();

            Console.WriteLine();                                      //줄 바꿈 처리
            /*Console.WriteLine("인벤토리:");                         // 상태창에서 바로 인벤토리가 보여지게 설정
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
            } 여기를 1번 누르면 인벤토리 창으로 들어가게 하자
            */
            Console.WriteLine("\n1. 인벤토리 보기");
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");
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
                Console.WriteLine("[무기]");
                foreach (var weapon in player.Inventory.Weapon)
                {
                    string prefix = weapon.IsEquipped ? "[E] ": "[ ] ";
                    Console.WriteLine($"- {prefix}{weapon.Name,-16} | +{weapon.AttackPoint} | {weapon.Text}");
                }

                Console.WriteLine("\n[방어구]");
                foreach (var armor in player.Inventory.Armors)
                {
                    string prefix = armor.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {prefix}{armor.Name,-16} | +{armor.ArmorPoint} | {armor.Text}");
                }

                Console.WriteLine("\n[방패]");
                foreach (var shield in player.Inventory.Shild)
                {
                    string prefix = shield.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {prefix}{shield.Name,-16} | +{shield.ArmorPoint} +{shield.AttackPoint} | {shield.Text}");
                }

                Console.WriteLine("\n[포션]");
                foreach (var potion in player.Inventory.Potions)
                {
                    Console.WriteLine($"- {potion.Name} | +{potion.HealPoint} | {potion.Text}");
                }
            }

            Console.WriteLine("\n1. 장착 관리");
            Console.Write("""
                0. 나가기

                원하시는 행동을 입력해주세요.
                >>
                """);
         

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
                Console.WriteLine("[무기]");

                foreach (var weapon in player.Inventory.Weapon)
                {
                    string prefix = weapon.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {Count,-2} {prefix}{weapon.Name,-16} | +{weapon.AttackPoint} | {weapon.Text}");
                    Count++;
                }

                Console.WriteLine("\n[방어구]");
                foreach (var armor in player.Inventory.Armors)
                {
                    string prefix = armor.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {Count, -2} {prefix}{armor.Name,-16} | +{armor.ArmorPoint} | {armor.Text}");
                    Count++;
                }

                Console.WriteLine("\n[방패]");
                foreach (var shield in player.Inventory.Shild)
                {
                    string prefix = shield.IsEquipped ? "[E] " : "[ ] ";
                    Console.WriteLine($"- {Count,-2} {prefix}{shield.Name,-16} | +{shield.ArmorPoint} +{shield.AttackPoint} | {shield.Text}");
                    Count++;
                }

                Console.WriteLine("\n[포션]");
                foreach (var potion in player.Inventory.Potions)
                {
                    Console.WriteLine($"- {potion} {potion.Name} | +{potion.HealPoint} | {potion.Text}");
                }
            }

            Console.WriteLine("\n0. 나가기\n");
            Console.Write("""
                원하시는 행동을 입력해주세요.
                >>
                """);
            
        }
        public void ErrorMessage()
        {
            Console.WriteLine("잘못된 입력입니다 ");
        }

        public void ShowNPC()
        {

            Console.Write($"""
               여관으로 왔습니다. 

               1. 퀘스트 받기
               2. 휴식하기

               0. 나가기

               원하시는 행동을 입력해주세요. 
               >> 
               """);

        }
        public void ShowQuestList(List<Quest> quests)
        {
            Console.WriteLine("퀘스트를 선택하세요.\n");

            for (int i = 0; i < quests.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {quests[i].Name}");
            }

            Console.Write($"""

               4. 진행 중인 퀘스트 보기

               0. 나가기

               원하시는 행동을 입력해주세요. 
               >> 
               """);
        }

        public void ShowQuestInfo(Quest quest)
        {
            Console.Write($"""
            {quest.Name}
            {quest.Text}

            잡을 몬스터: {quest.Target} {quest.TargetCount}마리
            보상: 골드 {quest.Gold}G

            1. 퀘스트 받기

            0. 나가기

            원하시는 행동을 입력해주세요.
            >> 
            """);
        }

        public void ShowAcceptQuest(string questName)
        {
            Console.Write($"""
               '{questName}' 퀘스트를 수락했습니다. 

               0. 나가기

               원하시는 행동을 입력해주세요. 
               >> 
               """);
        }



        public void ShowAlreadyAcceptedQuest()
        {

            Console.Write($"""
               퀘스트 1
               퀘스트 설명
               잡을 몬스터 : 이름, 마릿수
               보상 : 

               퀘스트를 받으시겠습니까?

               1. 퀘스트 받기

               0. 나가기

               원하시는 행동을 입력해주세요. 
               >>
               """);
        }

        public void ShowViewAcceptedQuest()
        {
            Console.Write($"""
               받은 퀘스트 목록
               -
               -

               퀘스트를 받으시겠습니까?

               1. 퀘스트 받기

               0. 나가기

               원하시는 행동을 입력해주세요. 
               >> 
               """);
        }

        public void ShowQuest3Info()
        {
            Console.Write($"""
               퀘스트 3 
               퀘스트 설명
               잡을 몬스터 : 이름, 마릿수
               보상 : 골드

               퀘스트를 받으시겠습니까?

               1. 퀘스트 받기
               
               0. 나가기

               원하시는 행동을 입력해주세요. 
               >> 
               """);
        }

        public void ShowReceiveQuest1()
        {
            Console.Write($"""
               (퀘스트 이름1) 퀘스트를 받았습니다.

               0. 나가기

               원하시는 행동을 입력해주세요. 
               >> 
               """);

        }
        public void ShowReceiveQuest2()
        {
            Console.Write($"""
               (퀘스트 이름2) 퀘스트를 받았습니다.

               0. 나가기

               원하시는 행동을 입력해주세요. 
               >> 
               """);

        }
        public void ShowReceiveQuest3()
        {
            Console.Write($"""
               (퀘스트 이름3) 퀘스트를 받았습니다.

               0. 나가기

               원하시는 행동을 입력해주세요. 
               >> 
               """);

        }

        public void ShowRest(Player player)
        {
            Console.Write($"""
               500 G 를 소모하여 체력을 회복할 수 있습니다. (보유 골드 : {player.Gold} G)

               1. 휴식하기
               0. 나가기

               원하시는 행동을 입력해주세요. 
               >> 
               """);
        }

        public void ShowRestSuccess(Player player)
        {
            Console.Write($"""
               [휴식 완료] 체력이 모두 회복되었습니다. (남은 골드 : {player.Gold} G)

               0. 나가기

               원하시는 행동을 입력해주세요.
               >> 
               """);

        }

        public void ShowRestFail()
        {
            Console.Write($"""
               [실패] 골드가 부족합니다.

               0.나가기

               원하시는 행동을 입력해주세요.
               >> 
               """);
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
            Console.Write($$"""
               0. 나가기 

               원하시는 행동을 입력해주세요. 
               >> 
               """);
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

            foreach (var weapon in shop.Inventory.Weapon)
            { 
                Console.WriteLine($"- {Count,-2} {weapon.Name,-16} | +{weapon.AttackPoint,-5} | {weapon.Price,-5} meso | {weapon.Text} ");
                Count++;
            }

            Console.WriteLine("\n[방어구]\n");
            foreach (var armor in shop.Inventory.Armors)
            {
                
                Console.WriteLine($"- {Count,-2} {armor.Name,-16} | +{armor.ArmorPoint,-5} | {armor.Price} meso | {armor.Text,-15}");
                Count++;
            }

            Console.WriteLine("\n[방패]\n");
            foreach (var shield in shop.Inventory.Shild)
            {
                
                Console.WriteLine($"- {Count,-2} {shield.Name,-16} | +{shield.ArmorPoint,-5} +{shield.AttackPoint} | {shield.Price} meso | {shield.Text,-15}");
                Count++;
            }
            
            Console.Write("""
                --------------------------------------------------------------
                1. 아이템 구매
                2. 아이템 판매
                0. 나가기

                원하시는 행동을 입력해주세요.
                >> 
                """);



        }
        public void BuyItem(Player player, Shop shop)
        {
            int Count = 1;

            Console.Write($"""
                상점에 오신 것을 환영합니다!
                필요한 아이템을 골드로 구매하실 수 있습니다 :3

                [보유 골드]
                {player.Gold}
                
                [아이템 목록]


                """);

            foreach (var weapon in shop.Inventory.Weapon)
            {
                Console.WriteLine($"- {Count,-2} {weapon.Name,-16} | +{weapon.AttackPoint,-5} | {weapon.Price,-5} meso | {weapon.Text} ");
                Count++;
            }

            Console.WriteLine("\n[방어구]");
            foreach (var armor in shop.Inventory.Armors)
            {
                Console.WriteLine($"- {Count,-2} {armor.Name,-16} | +{armor.ArmorPoint,-5} | {armor.Price} meso | {armor.Text,-15}");
                Count++;
            }

            Console.WriteLine("\n[방패]");
            foreach (var shield in shop.Inventory.Shild)
            {

                Console.WriteLine($"- {Count,-2} {shield.Name,-16} | +{shield.ArmorPoint,-5} +{shield.AttackPoint} | {shield.Price} meso | {shield.Text,-15}");
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
                필요한 아이템을 골드로 구매하실 수 있습니다 :3

                [보유 골드]
                {player.Gold}
                
                [아이템 목록]


                """);

            foreach (var weapon in player.Inventory.Weapon)
            {
                Console.WriteLine($"- {Count,-2} {weapon.Name,-16} | +{weapon.AttackPoint,-5} | {weapon.Price,-5} meso | {weapon.Text} ");
                Count++;
            }

            Console.WriteLine("\n[방어구]");
            foreach (var armor in player.Inventory.Armors)
            {

                Console.WriteLine($"- {Count,-2} {armor.Name,-16} | +{armor.ArmorPoint,-5} | {armor.Price} meso | {armor.Text,-15}");
                Count++;
            }

            Console.WriteLine("\n[방패]");
            foreach (var shield in player.Inventory.Shild)
            {

                Console.WriteLine($"- {Count,-2} {shield.Name,-16} | +{shield.ArmorPoint,-5} +{shield.AttackPoint} | {shield.Price} meso | {shield.Text,-15}");
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


    }

}

