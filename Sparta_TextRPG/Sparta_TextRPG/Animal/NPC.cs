using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class NPC
    {
        public Quest Quest { get; set; }


        public void Healing(Player player)  // 휴식 동작 기능
        {
            if (player.Gold >= 500)
            {
                player.Gold -= 500;
                Console.WriteLine("휴식을 완료했습니다.");
                player.NowHP = player.MaxHP;
            }
            else if (player.Gold < 500)
            {
                Console.WriteLine("Gold가 부족합니다.");
            }
        }




    }
}
