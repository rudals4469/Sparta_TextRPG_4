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
                player.NowHP = player.MaxHP;
                Messages.Instance().ShowHealing();
            }
            else if (player.Gold < 500)
            {
                Messages.Instance().ShowNoHealing();
           
            }
        }
    }
}
