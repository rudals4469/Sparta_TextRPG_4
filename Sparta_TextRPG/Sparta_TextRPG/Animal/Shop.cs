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

            
            { }
                  

            // item 을 받고 
            // 유무 확인
            // Inventory.Add(item);

            
            

        }












        // count : 전체의 수를 알려주는 int 리턴



        //숫자가 들어오면 
        // 예를들면 다 4개
        // 10
        //무기 4개 방어구 4 실드에 2번째걸 리턴 item

        public void SellItem(Player player, int selectedIndex)

        {
           
        
        

        }
    }
}
