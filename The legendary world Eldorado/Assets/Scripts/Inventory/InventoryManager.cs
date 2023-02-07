using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryCanva;
    public RectTransform SlotGameObject;
    public List<RectTransform> slotsGraphic;
    public List<Slot> slotsInfo;
    public PlayerMovement player;
    public PlayerStatistics stats;
    public bool removed = false;

    #region stats field

    public TextMeshProUGUI Health;
    public TextMeshProUGUI Mana;
    public TextMeshProUGUI Xp;
    public TextMeshProUGUI Money;
    public TextMeshProUGUI Lvl;
    #endregion

    private void Start()
    {
        InitializeValues();
        UpdateGraphic();
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenClose();
        }
    }

    public bool isIn(Item item)
    {
        bool check = false;
        foreach (Slot i in slotsInfo)
        {
            if (i.Item == item)
            {
                check = true;
                break;
            }
        }
        return check;
    }
    private void OpenClose()
    {
        if (player.blockInventory)
        {
            player.blockInventory = false;
            InventoryCanva.gameObject.SetActive(false);
        }
        else
        {
            player.blockInventory = true;
            InventoryCanva.gameObject.SetActive(true);
            UpdateGraphic();
        }
    }

    private void InitializeValues()
    {
        slotsGraphic = new List<RectTransform>();
        slotsInfo = new List<Slot>();
        foreach (RectTransform child in SlotGameObject)
            slotsGraphic.Add(child);
        for(int i = 0; i < slotsGraphic.Count; i++) {slotsInfo.Add(new Slot(ScriptableObject.CreateInstance<Item>()));}
    }
    
    public void UpdateGraphic()
    {
        for (int i = 0; i < slotsGraphic.Count; i++)
        {   
            if (slotsInfo[i].Item.type == "Empty")
            {
                foreach (RectTransform child in slotsGraphic[i])
                    child.gameObject.SetActive(false);
            }
            else
            {
                foreach (RectTransform child in slotsGraphic[i])
                    child.gameObject.SetActive(true);
                slotsGraphic[i].Find("Icon").GetComponent<Image>().sprite = slotsInfo[i].Item.itemSprite;
                slotsGraphic[i].Find("Number").GetComponent<TextMeshProUGUI>().text = slotsInfo[i].Stacks.ToString();
            }
        }

        Health.text = "Health : " + stats.currentHealth + "/" + stats.maxHealth;
        Mana.text = "Mana : " + stats.currentMana + "/" + stats.maxMana;
        Xp.text = "Xp : " + stats.currentXp + "/" + stats.maxXp;
        Lvl.text = "Lvl : " + stats.level;
        Money.text = "Money : " + stats.money;

    }

    public bool AddItem(Item item,int amount)
    {
        foreach (Slot slot in slotsInfo)
        {
            if (slot.Item.Id == item.Id && amount > 0)
            {
                if (item.maxStack - slot.Stacks >= amount)
                {
                    slot.Stacks += amount;
                    amount = 0;
                }
                else
                {
                    int many = item.maxStack - slot.Stacks;
                    slot.Stacks += many;
                    amount -= many;
                }
            }
        }

        if (amount > 0)
        {
            foreach (Slot slot in slotsInfo)
            {
                if (slot.Item.type == "Empty" && amount > 0)
                {
                    if (amount <= item.maxStack)
                    {
                        slot.Stacks = amount;
                        slot.Item = item;
                        amount = 0;
                    }
                    else
                    {
                        slot.Stacks = item.maxStack;
                        slot.Item = item;
                        amount -= item.maxStack;
                    }
                }
            }
        }
        UpdateGraphic();
        return amount == 0;
    }

    public bool RemoveItem(Item item, int value)
    {
        foreach(Slot slot in slotsInfo)
        {
            if (value > 0 && slot.Item.Id == item.Id)
            {
                if (value <= slot.Stacks)
                {
                    slot.Stacks -= value;
                    stats.money += (value * item.itemPrice)/3;
                    value = 0;
                }
                else
                {
                    value -= slot.Stacks;
                    stats.money += (slot.Stacks *item.itemPrice)/3;
                    slot.Stacks = 0;
                }
            }
            if (slot.Stacks == 0)
            {
                slot.Item = ScriptableObject.CreateInstance<Item>();
            }
        }
        UpdateGraphic();
        removed = true;
        return value == 0;
    }

    public void RemoveItemSlot(int slot,int amount)
    {
        if (amount <= slotsInfo[slot].Stacks)
            stats.money += amount * slotsInfo[slot].Item.itemPrice;
        else
            stats.money += slotsInfo[slot].Stacks * slotsInfo[slot].Item.itemPrice;
        slotsInfo[slot].Stacks -= amount;
        if (slotsInfo[slot].Stacks <= 0)
        {
            slotsInfo[slot].Item = ScriptableObject.CreateInstance<Item>();
        }
        UpdateGraphic();
        removed = true;
    }
    
    public class Slot
    {
        private string _type;
        
        public Item Item { get; set; }

        public int Stacks { get; set; }

        public Slot(Item item)
        {
            this.Item = item;
            Stacks = 0;
            _type = item.type;
        }
    }
}
