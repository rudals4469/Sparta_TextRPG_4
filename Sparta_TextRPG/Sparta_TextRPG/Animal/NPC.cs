using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class NPC
    {

        public bool Rest(Player player)  // 휴식하기 기능
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
