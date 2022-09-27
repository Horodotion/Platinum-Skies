using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GeneralManager : MonoBehaviour
{
    public static GeneralManager instance;
    public static PlayerController[] playerList = new PlayerController[4];
    public GameObject planePrefab;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
    }

    public static void RegisterPlayer(PlayerController newPlayer)
    {
        for (int i = 0; i < playerList.Length; i++)
        {
            if (playerList[i] == null)
            {
                playerList[i] = newPlayer;
                newPlayer.playerID = i;
                break;
            }
        }
    }

    public void SpawnVehicle(PlayerController player, VehicleType typeToSpawn)
    {
        switch (typeToSpawn)
        {
            case (VehicleType.plane):
                GameObject newVehicle = Instantiate(planePrefab, player.transform.position, player.transform.rotation);
                newVehicle.GetComponent<Vehicle>().Initialize(player);
                break;
        }
        
    }
}
