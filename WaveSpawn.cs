﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    //Prefab target
    public Transform enemyPrefab;

    //spawnPoint target
    public Transform spawnPoint;

    public float timeBetweenWaves ;
    private float countdown;
    private int waveNumber = 1;

    private void Update()
    {
        //countdown spawn
        if (countdown <= 0)
        {
            //run method spwanWave
            spwanWave();
            //set up countdown Equal to timeBetweenWaves
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    private void spwanWave ()
    {
        //Loop for create SpawnMonster
        for (int i = 0; i < waveNumber; i++)
        {
            //run method SpawnEnemy()
            SpawnEnemy();
        }
    }
    public  void SpawnEnemy()
    {
        //Create Object enemyPrefab
        Instantiate(enemyPrefab);
    }
}
