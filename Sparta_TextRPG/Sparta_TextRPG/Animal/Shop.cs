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
        //아이템을 해당 번호에 맞게 찾아오는 함수
        public Item GetItemByIndex(int index)
        {
            if (index < Inventory.Weapon.Count)
                return Inventory.Weapon[index];
            index -= Inventory.Weapon.Count;

            if (index < Inventory.Armors.Count)
                return Inventory.Armors[index];
            index -= Inventory.Armors.Count;

            if (index < Inventory.Shild.Count)
                return Inventory.Shild[index];
            index -= Inventory.Shild.Count;

            if (index < Inventory.Potions.Count)
                return Inventory.Potions[index];

            return null;
        }
        //상점이 유저의 아이템을 산다. 유저입장에서는 파는것 
        public void BuyItem(Player player, int selectedIndex)
        {
            Item item = player.Inventory.GetItemByIndex(selectedIndex);

            if (item == null)
                return;

            // 골드 지급
            player.Gold += item.Price;

            // 플레이어 인벤토리에서 제거
            player.Inventory.Remove(item);
            
            AddItem(item);
        }



        public bool SellItem(Player player, int selectedIndex)

            {
                Item item = GetItemByIndex(selectedIndex);
               
                if (player.Gold < item.Price)
                    return false;

                player.Gold -= item.Price;
                player.Inventory.Add(item);
                
                return true;
            }


        
    }
}
