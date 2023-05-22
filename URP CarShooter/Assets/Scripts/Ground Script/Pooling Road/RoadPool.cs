using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPool : MonoBehaviour
{
    public static RoadPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    List<GameObject> roads = new List<GameObject>();

    private int amountToPool = 10;
    [SerializeField] private GameObject roadPrefab;
    [SerializeField] private GameObject roadParent;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(roadPrefab);
            obj.transform.parent = roadParent.transform;
            obj.SetActive(false);
            pooledObjects.Add(obj);

           
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                roads.Add(pooledObjects[i]);
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }
        return null;
    }
    public void DisableRoad()
    {
        roads[0].gameObject.SetActive(false);
        roads.RemoveAt(0);
    }
}
