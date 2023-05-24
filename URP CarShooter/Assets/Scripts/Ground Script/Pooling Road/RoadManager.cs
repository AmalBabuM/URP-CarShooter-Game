using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    private Transform playerTransform;
    private float spawnZ = -10.0f;
    private float tileLength = 60.0f;
    private int tileOnScreen = 5;
    private float safeZone = 100.0f;

    public RoadPool roadPool;

    /*private List<GameObject> activeTile;*/
    private int lastPrefabIndex = 0;
    void Start()
    {
        /*activeTile = new List<GameObject>();*/
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < tileOnScreen; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - tileOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }
    void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)

            //go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
            go = roadPool.GetPooledObject();
        else
            //go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

            go = roadPool.GetPooledObject();

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
       /* activeTile.Add(go);*/
    }
    void DeleteTile()
    {
        roadPool.DisableRoad();
    }
    /*int RandomPrefabIndex()
    {
       *//* if (tilePrefabs.Length <= 1)*//*

            return 0;
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;*//*
    }*/
}
