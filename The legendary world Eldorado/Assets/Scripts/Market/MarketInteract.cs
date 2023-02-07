using UnityEngine;

public class MarketInteract : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collider)
    {
    
        if (collider.CompareTag("Player"))
        {
            
            collider.GetComponent<PlayerHitMarket>().isTrigger = true;
            collider.GetComponent<PlayerHitMarket>().market = GetComponent<Market>();  
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            collider.GetComponent<PlayerHitMarket>().isTrigger = false;
    }
}
