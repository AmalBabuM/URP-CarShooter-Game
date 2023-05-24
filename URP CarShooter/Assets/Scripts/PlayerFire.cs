using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    bool isfired = false;
    [SerializeField] private float timeInterval = 1f;
    [SerializeField] private Transform playerFirePoint;
    public BulletPool bulletPool;
    bool isAlive = true;

    private void OnEnable()
    {
        FireButton.isPressedAction += Fire;
        
    }
    private void OnDisable()
    {
        FireButton.isPressedAction -= Fire;
    }
   /* private void Update()
    {
        if (!isfired)
        {
            StartCoroutine(EnemyFire());
            isfired = true;
        }
    }*/
    public void Fire(bool val)
    {
        if (!isfired&& val)
        {
            StartCoroutine(EnemyFire());
            isfired = true;
        }


    }

    private IEnumerator EnemyFire()
    {
        yield return new WaitForSeconds(timeInterval);
        GameObject bullet = bulletPool.GetPooledObject();
        if (bullet != null && isAlive)
        {
            bullet.transform.position = playerFirePoint.position;
            bullet.transform.rotation = playerFirePoint.rotation;
            bullet.SetActive(true);
        }
        isfired = false;
    }
}
