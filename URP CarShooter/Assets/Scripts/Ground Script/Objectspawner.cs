using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectspawner : MonoBehaviour
{
    private bool spawningObject=false;

    [SerializeField] private float groundSpawnDistance = 50f;
    public static Objectspawner instance;

    private void Awake()
    {
        instance= this;
    }

    public void SpawnGround()
    {
        ObjectPool.instance.SpawnFromPool("ground",new Vector3(0,0,groundSpawnDistance),Quaternion.identity);
    }
}
