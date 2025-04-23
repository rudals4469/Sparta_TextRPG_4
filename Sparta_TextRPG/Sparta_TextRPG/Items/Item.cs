using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Item
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int Price { get; set; }

        public ItemType Type { get; set; }

        public Item(string name, string text , int price , ItemType type)
        {
            this.Name = name;
            this.Text = text;
            this.Price = price;
            this.Type = type;
        }
    }
}
