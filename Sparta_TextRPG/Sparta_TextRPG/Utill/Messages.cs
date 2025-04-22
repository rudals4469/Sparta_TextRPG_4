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
            if(instance == null)
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
        public void ShowBattelStart(List<Monster> monsters, Player player)
        {
            foreach (var item in monsters)
            {
                Console.WriteLine($"Lv.{item.Level} {Monster.MonsterName.ToString()} HP {Monster.HP}");
            }
            Console.WriteLine(
               $"""
               

                
               """
                );

        }

        public void ShowStatus(Player player)         //$""" 사용해보려 하였으나 익숙치 않아 익숙한 것으로 진행
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine();                                       //줄 바꿈 처리
            Console.WriteLine($"Lv. {player.Level}");
            Console.WriteLine($"{player.Name} ( {player.Class} )");
            Console.WriteLine($"공격력 : {player.Attack}");
            Console.WriteLine($"방어력 : {player.Armor}");
            Console.WriteLine($"체  력 : {player.HP}");                //원본 가이드에서 띄어쓰기 되어있음
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();                                      //줄 바꿈 처리
            Console.WriteLine("인벤토리");                             //player 인벤토리로 받을 수 있게 처리
            foreach (var item in player.Inventory)                    //배열 리스트 순차적으로 꺼내서 처리(var 변수 타입 결정 player인벤토리 안에 있는 아이템 전부 item처리)
                Console.WriteLine($" - {item.Name} x{item.Quantity}"); //아이템 이름과 수량
            Console.WriteLine();                                      //줄 바꿈 처리
            Console.WriteLine("\n0.나가기");
            while (Console.ReadLine() != "0") Console.WriteLine("0을 입력해주세요.\n>> ");  //사용자가 "0"을 입력할 때까지 반복문 실행 출력
            


        }
    }

}

