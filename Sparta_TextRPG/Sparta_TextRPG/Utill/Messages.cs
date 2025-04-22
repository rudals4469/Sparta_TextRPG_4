using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("인벤토리");                             //player 인벤토리로 받을 수 있게 처리
            //인벤토리 출력은 4단계를 거쳐서 작성해야함
            foreach (var item in player.Inventory)                    //배열 리스트 순차적으로 꺼내서 처리(var 변수 타입 결정 player인벤토리 안에 있는 아이템 전부 item처리)
                Console.WriteLine($" - {item.Name} x{item.Quantity}"); //아이템 이름과 수량
            Console.WriteLine();                                      //줄 바꿈 처리
            Console.WriteLine("\n0.나가기");
            while (Console.ReadLine() != "0") Console.WriteLine("0을 입력해주세요.\n>> ");  //사용자가 "0"을 입력할 때까지 반복문 실행 출력
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
               500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {0} G)

               1. 휴식하기
               2. 나가기

               원하시는 행동을 입력해주세요. 
               >> 
               """, player.Gold);
        }
        public void ShowDungoun()
        {
            Console.Write($"""
               던전입장
               이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다. 
               
               1. 쉬운 던전     | 방어력 5 이상 권장
               2. 일반 던전     | 방어력 11 이상 권장
               3. 어려운 던전   | 방어력 17 이상 권장
               0. 나가기 

               원하시는 행동을 입력해주세요. 
               >>
               """);
        }
    }

}

