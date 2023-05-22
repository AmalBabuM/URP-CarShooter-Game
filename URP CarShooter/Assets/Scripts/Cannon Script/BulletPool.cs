using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 20;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletParent;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    void Start()
    {
        for(int i=0;i<amountToPool;i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.transform.parent = bulletParent.transform;
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        for(int i=0;i< pooledObjects.Count;i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}