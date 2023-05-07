using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    public GameObject[] playerPrefabs;
    private int EnemyShips;
    public int ActiveEnemyShips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MissionSetup(int mission)
    {
        switch (mission)
        {
            case 0:
                //Tutorial
                EnemyShips = 2;
                ActiveEnemyShips = 2;
                //Instantiate;
                break;
            case 1:
                // Mission 1
                break;
        }
    }
}
