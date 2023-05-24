using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 4f;
    GameObject player;
    public float destroyTime = 2f;
    void Start()
    {
        
        rb= GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnEnable()
    {
        Invoke("BulletDeactivation", destroyTime);
    }

    void Update()
    {
        
        rb.velocity=transform.forward*speed;

        /*if (Vector3.Distance(player.transform.position, transform.position) > 30f)
        {
            BulletDeactivation();
        }*/

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        /*Debug.Log("Heyy");*/

        Damage obj=collision.gameObject.GetComponent<Damage>();
        if(obj != null)
        {

        obj.GetDamage(10);
        }

        /*if (collision.gameObject.CompareTag("Player"))
        {
            *//*playerLife.TakeDamage();*//*
        }*/
        /*else if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy= collision.gameObject.GetComponent<Enemy>();
            enemy.StartCoroutine("EnemyDied");
        }*/

        BulletDeactivation();
    }
    void BulletDeactivation()
    {
        gameObject.SetActive(false);
    }
}
