using System;
using TMPro;
using UnityEngine;

namespace Inventory
{
    public class ButtonInventoryManager : MonoBehaviour
    {
        
        public int SlotDelete;
        public InventoryManager inventory;
        public TextMeshProUGUI count;

        #region info
        public GameObject potionCanvas;
        public TextMeshProUGUI namePotion;
        public TextMeshProUGUI amountPotion;
        public TextMeshProUGUI pricePotion;
        public GameObject weaponCanvas;
        public TextMeshProUGUI nameWeapon;
        public TextMeshProUGUI damageWeapon;
        public TextMeshProUGUI priceWeapon;
        public GameObject otherCanvas;
        public TextMeshProUGUI nameOther;
        public TextMeshProUGUI priceOther;
        public Bar bar;
        private int actualSlot;
        #endregion

        public void UseInBar(int BarNumber)
        {
            bar.Items[BarNumber] = inventory.slotsInfo[actualSlot].Item;
            bar.change = true;
        }

        public void SlotButton(int SlotNumber)
        {
            actualSlot = SlotNumber;
            Item item = inventory.slotsInfo[SlotNumber].Item;
            if (item.type == "Potion")
            {
                potionCanvas.SetActive(true);
                namePotion.text = "Name : " + item.itemName;
                pricePotion.text = "Price : " + item.itemPrice;
                amountPotion.text = "Utility amount : " + item.potionAmount;
            }
            else if(item.type == "Sword" || item.type == "Bow")
            {
                weaponCanvas.SetActive(true);
                nameWeapon.text = "Name : " + item.itemName;
                priceWeapon.text = "Price : " + item.itemPrice;
                damageWeapon.text = "Damage : " + item.damage;
            }
            else
            {
                otherCanvas.SetActive(true);
                nameOther.text = "Name : " + item.itemName;
                priceOther.text = "Price : " + item.itemPrice;
            }
        }

        public void SlotNumberToDelete(int toDelete)
        {
            SlotDelete = toDelete;
        }

        public void UpdateCount(int whichButton)
        {
            switch (whichButton)
            {
                case 1:
                    count.text = "1";
                    break;
                case 2:
                    int actualValue = Int32.Parse(count.text);
                    if(actualValue < inventory.slotsInfo[SlotDelete].Stacks)
                        count.text = (actualValue + 1).ToString();
                    break;
                case 3:
                    int actualValue2 = Int32.Parse(count.text);
                    if(actualValue2 > 1)
                        count.text = (actualValue2 - 1).ToString();
                    break;
                case 4:
                    count.text = inventory.slotsInfo[SlotDelete].Stacks.ToString();
                    break;
                default:
                    count.text = "1";
                    break;
            }
        }
        
        public void Validate()
        {
            inventory.RemoveItemSlot(SlotDelete,Int32.Parse(count.text));
        }
    
    }
}
