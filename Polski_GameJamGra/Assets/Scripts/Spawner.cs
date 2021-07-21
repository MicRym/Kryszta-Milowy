﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    bool Active;
    [SerializeField]
    GameObject[] SpawnedObject;
    [SerializeField]
    float SpawnPeriod;
    float LastSpawn;
    [SerializeField]
    Enemy.SpriteDirection direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Active) return;
        GameObject spawn;
        if (Time.timeSinceLevelLoad - LastSpawn < SpawnPeriod) return;
        LastSpawn = Time.timeSinceLevelLoad;
        if(SpawnedObject.Length<2)  spawn = Instantiate(SpawnedObject[0]);
        else  spawn=Instantiate(SpawnedObject[Random.Range(0,SpawnedObject.Length)]);
        spawn.GetComponent<Enemy>().Direction = direction;
        spawn.transform.position = transform.position;
        spawn.transform.parent = transform;

    }
}
