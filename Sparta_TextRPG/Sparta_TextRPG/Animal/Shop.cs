using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Shop
    {
        public Inventory Inventory { get; set; }

        //왜 item-void 이고 string-item인지
        //함수를 SellItem, AddItem, 

        public void show() 
        {
            Console.WriteLine("상점에 오신 것을 환영합니다");   
        
        }
        public void main()
        {
            show();
        }

        public void AddItem(Item item)
        {
            Inventory.Add(item);
        }

        public void BuyItem()
        {

        }
        

        public void SellItem()
        {

        }
    }
}
