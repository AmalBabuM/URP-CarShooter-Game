using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool isfired = false;
    [SerializeField] private float timeInterval = 2f;
    [SerializeField] private Transform enemyFirePoint;
    bool isAlive = true;
    private Transform player;
    public BulletPool bulletPool;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        RotateTowardsPlayer();
        if (!isfired)
        {
            StartCoroutine(EnemyFire());
            isfired = true;
        }
     
        
    }
    private void RotateTowardsPlayer()
    {
        if (player != null)
        {
            transform.LookAt(player.transform.position);
        }
    }

    private IEnumerator EnemyFire()
    {
        yield return new WaitForSeconds(timeInterval);
        GameObject bullet = bulletPool.GetPooledObject();
        if (bullet != null&&isAlive)
        {
            bullet.transform.position = enemyFirePoint.position;
            bullet.transform.rotation = enemyFirePoint.rotation;
            bullet.SetActive(true);
        }
        isfired = false;
    }
}
