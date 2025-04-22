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
    }
}
