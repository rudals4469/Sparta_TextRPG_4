using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sparta_TextRPG
{
    internal class Shop
    {
        public Inventory Inventory { get; set; }

        //왜 item-void 이고 string-item인지
        //함수를 SellItem, AddItem, 해야하는데 buyitem에선 사람이 구매를 누르고 장비에 따라 번호를 누르면 그 번호에 해당하는 게 얼마인지에 따라 본인 돈을 확인 뒤 돈이적은지 많은지에 따라 사지거나 못 산다는 문구를 표출.
        //구매를 하면 장비는 인벤토리에도 들어가야 하고, 상점에는 구매 완료 라고 떠야 함.
        //그럼 함수만 넣어야한다면 ButItem에는 사람이 번호를 누르고
        //sellitem 에서는 사람이 판매를 누르고 장비에 따라 번호를 누르면 그 장비가 팔리게 됨
        //판매를 하면 장비는 인벤토리에서 없어져야 하고상점에는 다시 값어치로 뜨게 됨

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

        //상점이 유저의 아이템을 산다. 유저입장에서는 파는것
        public void BuyItem(Item item)
        {


            // item 을 받고 
            // 유무 확인
            // Inventory.Add(item);


            Console.WriteLine("구매 가능한 아이템 목록");
            Inventory.Add(item);
            for (int i = 0; i < Inventory.Count; i++);
            {
                Item itemmm = ShopItems[i];
                Console.WriteLine($"{i + 1}. {item.Name} - {item.Price}골드");

            }

            Console.Write("구매할 아이템 번호를 입력하세요: ");
            string input = Console.ReadLine();


            if (int.TryParse(input, out int choice) && choice > 0 && choice <= shopItems.Count)
            { }
                  

            // item 을 받고 
            // 유무 확인
            // Inventory.Add(item);

            
            

        }




        








        
     public void SellItem(Player player, int selectedIndex)

        { 
            List<Item> shopItems = Inventory.GetAllItems();


        if (selectedIndex < 0 || selectedIndex >= shopItems.Count)
                return;

            Item selectedItem = shopItems[selectedIndex];

            if (player.Gold < selectedItem.Price)
                return;


            player.Gold -= selectedItem.Price;


            player.Inventory.Add(selectedItem); 
        
        

        }
    }
}
