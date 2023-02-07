using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class Market : MonoBehaviour
{
    public Item item1;
    public Item item2;
    public Item item3;
    public string type;
    public AudioSource audioSource;
    public AudioClip sound;

    //Generation de N nombres aléatoires pour avoir une génération d'items aléatoire
    private List<int> randomValue(int nb,int length)
    {
        int temp;
        Random rand = new Random();
        List<int> myNumbers = new List<int>();
        for (int i = 0; i < nb; i++)
        {
            temp = rand.Next(0, length);
            while (myNumbers.Contains(temp))
            {
                temp = rand.Next(0, length);
            }
            myNumbers.Add(temp);
        }
        return myNumbers;
    }
    
    void Start()
    {
        Item[] fromRessources = Resources.LoadAll<Item>("ItemData/" + type);
        List<int> myNumbers = randomValue(3, fromRessources.Length);
        (item1, item2, item3) = (fromRessources[myNumbers[0]], fromRessources[myNumbers[1]], fromRessources[myNumbers[2]]);
    }
}
