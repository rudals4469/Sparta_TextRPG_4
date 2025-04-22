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
