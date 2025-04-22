using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Player : Animal //animal에 상속       
    {
        public int MaxExp {  get; set; } //exp

        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public Shiled Shiled { get; set; }
        public Potion Potion { get; set; }

    }
    
}
