using System;
using UnityEngine;
using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;

public class SpawnPlayer : MonoBehaviourPun
{
    public GameObject playerPrefab;
    void Start()
    {
        getData();
    }
    private void getData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(),spawn,OnError);
    }
    private void OnError(PlayFabError result)
    {
        Debug.Log(result);
    }
    private void spawn(GetUserDataResult data)
    {
        Vector2 vect = new Vector2(0, 0);
        GameObject instance = PhotonNetwork.Instantiate(playerPrefab.name, vect, Quaternion.identity);
        Camera child = instance.GetComponentInChildren<Camera>();
        child.enabled = true;
        PlayerStatistics stats = instance.GetComponent<PlayerStatistics>();
        PlayerMovement speed = instance.GetComponent<PlayerMovement>();
        //setup variable depuis sauvegarde en ligne
        #region saved data
        string[] position = data.Data["Position"].Value.Split('/');
        instance.transform.position = new Vector3(float.Parse(position[0]), float.Parse(position[1]), 0);
        stats.currentHealth = Int32.Parse(data.Data["Hp"].Value);
        stats.maxHealth = Int32.Parse(data.Data["MaxHp"].Value);
        stats.currentMana = Int32.Parse(data.Data["Mana"].Value);
        stats.maxMana = Int32.Parse(data.Data["MaxMana"].Value);
        stats.currentXp = Int32.Parse(data.Data["Xp"].Value);
        stats.level = Int32.Parse(data.Data["Level"].Value);
        stats.money = Int32.Parse(data.Data["Money"].Value);
        speed.speed = float.Parse(data.Data["Speed"].Value);
        stats.damage = Int32.Parse(data.Data["Damage"].Value);
        #endregion


    }
}
