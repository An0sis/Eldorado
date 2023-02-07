using UnityEngine;

[CreateAssetMenu(menuName = "Item" , fileName = "New Item")]
public class Item : ScriptableObject
{
    public string type;
    private string itemRarity;
    public string itemName;
    public string itemDest;
    public Sprite itemSprite;
    public int itemPrice;
    public int Id;
    public int maxStack;
    public int maxDamage;
    public int minDamage;
    public int damage;
    public int range;
    public int loadingTime;
    public string potionType;
    public int potionAmount;

    public Item()
    {
        type = "Empty";
    }
}


