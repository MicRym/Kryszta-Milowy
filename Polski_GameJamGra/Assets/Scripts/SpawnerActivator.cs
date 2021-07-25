using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerActivator : MonoBehaviour
{
    [SerializeField]
    GameObject GameController;
    [SerializeField]
    List<Spawner> Spawners;
    [SerializeField]
    float SpawnPeriod;
    float LastSpawn;
    [SerializeField]
    int CountOfActiveSpawners=1;
    bool Active = true;
    // Start is called before the first frame update
    void Start()
    {
        GameController.GetComponent<GameController>().OnStageChange += stage => SpawnPatternUpdate(stage);
        GameController.GetComponent<GameController>().OnGameOverWin += () => Active = false;
    }

    private void SpawnPatternUpdate(int stage)
    {
        switch(stage)
        {
            case 1:
                CountOfActiveSpawners = 1;
                break;
            case 2:
                CountOfActiveSpawners = 2;
                break;
            case 3:
                CountOfActiveSpawners = 3;
                break;
            case 4:
                CountOfActiveSpawners = 4;
                break;
            default:
                CountOfActiveSpawners = 2;
                break;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (!Active) return;

        if (Time.timeSinceLevelLoad - LastSpawn < SpawnPeriod) return;
        else
        {
            List<Spawner> CurrentSpawners=new List<Spawner>();
            for (int i = 0; i < CountOfActiveSpawners; i++)
                CurrentSpawners.Add(Spawners[Random.Range(0, 16)]);
            foreach (Spawner spawner in CurrentSpawners)
                spawner.Spawn();
            LastSpawn = Time.timeSinceLevelLoad;


        }
    }
}
