using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    /*public float rotationSpeed = 10f;*/
    public float detectionRadius = 10f;
    /*public float fireCooldown = 0.2f;*/
   /* public GameObject[] bulletPrefab; */// Drag and drop the bullet prefab here
    /*public Transform bulletSpawnPoint;*/
    /*public float bulletSpeed = 5f;*/

    private Transform player;
    /*private float fireTimer;*/

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming the player has the "Player" tag
        /*fireTimer = 0f;*/
    }

    private void Update()
    {
        RotateTowardsPlayer();

        /*if (IsPlayerInRange() && fireTimer <= 0f)
        {
            *//*FireBullet();*//*
            fireTimer = fireCooldown;
        }

        if (fireTimer > 0f)
        {
            fireTimer -= Time.deltaTime;
        }*/
    }

    private void RotateTowardsPlayer()
    {
        if (player != null)
        {
            /*Vector3 direction = player.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(direction);*/
            transform.LookAt(player.transform.position);
        }
    }

   /* private bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.position) <= detectionRadius;
    }*/

    /*private void FireBullet()
    {
        *//*GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.SetActive(true);*//*
        for(int i=0;i<bulletPrefab.Length;i++)
        {
            if (!bulletPrefab[i].activeInHierarchy)
            {
                bulletPrefab[i].transform.position = bulletSpawnPoint.position;
                *//*bulletPrefab[i].transform.rotation = bulletSpawnPoint.rotation;*//*
                bulletPrefab[i].SetActive(true);
                Rigidbody rbBullet = bulletPrefab[i].GetComponent<Rigidbody>();
                rbBullet.AddForce(transform.forward.normalized*bulletSpeed);
                *//*break;*//*
            }
        }
    }*/
}

