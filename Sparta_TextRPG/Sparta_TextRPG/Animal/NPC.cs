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


        public bool Rest(Player player)  // 휴식 동작 기능
        {
            if (player.Gold >= 500)
            {
                player.Gold -= 500;
                player.NowHP = player.MaxHP;
                return true;
            }   
            else if (player.Gold < 500)
            {
                return false;
            }
            return false;
        }
    }
}
