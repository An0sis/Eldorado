using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mort : MonoBehaviour
{
    public PlayerStatistics stats;
    public PlayerMovement position;
    // Update is called once per frame
    void Update()
    {
        if (stats.currentHealth <= 0)
        {
            position.transform.position = new Vector3(0, 0, 0);
            stats.currentHealth = stats.maxHealth;
            stats.money /= 2;
        }
    }
}
