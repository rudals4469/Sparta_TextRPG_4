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
        static Messages Instance()
        {
            if(instance == null)
            {
                instance = new Messages();
            }
            return instance;
        }
        
    }
}
