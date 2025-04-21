using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Quest
    {
        public string Name { get; set; }
        public string Text { get; set; }

        // Reward : items

        public int Gold { get; set; }
        public int State { get; set; }
        public string Target { get; set; } 
        public int RequestLevel { get; set; }

        // public void show() { }

    }
}
