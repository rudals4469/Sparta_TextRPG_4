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

        public void ShowStatus()         //$""" 사용해보려 하였으나 익숙치 않아 익숙한 것으로 진행
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine();                                       //줄 바꿈 처리
            Console.WriteLine($"Lv. {Player.Level}");
            Console.WriteLine($"{Player.Name} ( {Player.Job} )");
            Console.WriteLine($"공격력 : {Player.Attack}");
            Console.WriteLine($"방어력 : {Player.Defense}");
            Console.WriteLine($"체  력 : {Player.HP}");                //원본 가이드에서 띄어쓰기 되어있음
            Console.WriteLine($"Gold : {Player.Gold} G");
            Console.WriteLine();                                      //줄 바꿈 처리
            Console.WriteLine("1");
            Console.WriteLine("0.나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요. \n>> ");    //입력 대기 형식 유지하기 위해 \n>> 작성


        }
    }

}

