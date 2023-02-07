using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHitMarket : MonoBehaviour
{
    public Market market;
    public GameObject marketGUI;
    public bool open = false;
    public PlayerMovement player;
    public PlayerStatistics stats;
    public bool isTrigger = false;
    public InventoryManager inventory;

    #region variableMarket
    public Image sp1;
    public Image sp2;
    public Image sp3;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI money;
    #endregion
    
    public void setGUI()
    {
        sp1.sprite = market.item1.itemSprite;
        sp2.sprite = market.item2.itemSprite;
        sp3.sprite = market.item3.itemSprite;
        text1.text = market.item1.itemName;
        text2.text = market.item2.itemName;
        text3.text = market.item3.itemName;
        money.text = stats.money.ToString();
    }
    public void Update()
    {
        money.text = stats.money.ToString();
        if (Input.GetKeyDown(KeyCode.F) && isTrigger)
            if (open)
                StopInteractMarket();
            else
            {
                InteractMarket();   
            }
    }
    
    public void InteractMarket()
    {
        setGUI();
        marketGUI.SetActive(true);
        open = true;
        player.blockMarket = true;
    }
    
    public void StopInteractMarket()
    {
        marketGUI.SetActive(false);
        open = false;
        player.blockMarket = false;
    }

    public GameObject popUp;
    public Canvas gameObjectParent;
    public void Buy(int itemNumber)
    {
        Item toBuy = itemNumber == 1 ? market.item1 :
            itemNumber == 2 ? market.item2 : market.item3;
        if (toBuy.itemPrice < stats.money)
        {
            if(inventory.AddItem(toBuy,1))
                stats.money -= toBuy.itemPrice;
            else
            {
                Instantiate(popUp, gameObjectParent.transform, true);
            }
        }
        else
        {
            Instantiate(popUp, gameObjectParent.transform, true);
        }
    }
}
