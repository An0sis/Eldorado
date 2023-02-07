using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public InventoryManager inventory;
    public Item[] Items;
    public bool change = false;
    public int active;
    public Image sl1;
    public Image sl2;
    public Image sl3;
    public Image sl4;
    public Image sl5;
    private void Start()
    {
        Items = new Item[5];
        for (int i = 0; i < 5; i++)
            Items[i] = ScriptableObject.CreateInstance<Item>();
        active = 0;
    }
    private void Update()
    {
        if (inventory.removed)
        {
            for(int i = 0; i < 5; i ++)
            {
                if (!inventory.isIn(Items[i]))
                {
                    Items[i] = ScriptableObject.CreateInstance<Item>();
                    change = true;
                }
            }
            inventory.removed = false;
        }
        //Update graphic
        if (change)
        {
            if (Items[0].type != "Empty")
            {
                sl1.sprite = Items[0].itemSprite;
                sl1.color = new Color(255, 255, 255, 255);
            }
            else
                sl1.color = new Color(0, 0, 0, 0);
            if (Items[1].type != "Empty")
            {
                sl2.sprite = Items[1].itemSprite;
                sl2.color = new Color(255, 255, 255, 255);
            }
            else
                sl2.color = new Color(0, 0, 0, 0);
            if (Items[2].type != "Empty")
            {
                sl3.sprite = Items[2].itemSprite;
                sl3.color = new Color(255, 255, 255, 255);
            }
            else
                sl3.color = new Color(0, 0, 0, 0);
            
            if (Items[3].type != "Empty")
            {
                sl4.sprite = Items[3].itemSprite;
                sl4.color = new Color(255, 255, 255, 255);
            }
            else
                sl4.color = new Color(0, 0, 0, 0);
            
            if (Items[4].type != "Empty")
            {
                sl5.sprite = Items[4].itemSprite;
                sl5.color = new Color(255, 255, 255, 255);
            }
            else
                sl5.color = new Color(0, 0, 0, 0);

            change = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            active = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            active = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            active = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            active = 3;
        if (Input.GetKeyDown(KeyCode.Alpha5))
            active = 4;
            
    }
}
