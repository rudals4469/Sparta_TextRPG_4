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


            Console.Write($"""
                스파르타 던전에 오신여러분 환영합니다.
                원하시는 이름을 설정해주세요

                >>
                """);
        }
        //
        public void ShowBattelStart(List<Monster> monsters, Player player)
        {
            foreach (var item in monsters)
            {

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
    }
}
