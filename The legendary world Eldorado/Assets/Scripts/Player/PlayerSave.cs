using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Json;
using UnityEngine;

namespace Player
{
    public class PlayerSave : MonoBehaviour
    {
        public PlayerStatistics stats;
        public PlayerMovement speed;
        public InventoryManager inventory;
        void Update()
        {
            if (Input.GetKey(KeyCode.M))
            {
                Save();
            }
        }
        public void Save()
        {
            var position = gameObject.transform.position;
            var request = new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>()
                {
                    {"Position",position.x + "/" + position.y},
                    {"MaxHp",stats.maxHealth.ToString()},
                    {"MaxMana",stats.maxMana.ToString()},
                    {"Hp",stats.currentHealth.ToString()},
                    {"Mana",stats.currentMana.ToString()},
                    {"Xp",stats.currentXp.ToString()},
                    {"Level",stats.level.ToString()},
                    {"Speed",speed.speed.ToString()},
                    {"Money",stats.money.ToString()},
                    {"Damage",stats.damage.ToString()}
                }
            };
            PlayFabClientAPI.UpdateUserData(request,result => Debug.Log("saved"),error => Debug.Log("not saved"));
        }
    }
}