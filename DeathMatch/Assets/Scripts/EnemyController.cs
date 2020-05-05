﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemyHealth;
    public fireGun fireGunRef;
    public PlayerController playerConRef;
    public string enemMaterial;
    public GameObject heldWpn;
    public string heldWeaponTag;
    public EnemySpawn enemySpawnRef;
    public static bool resistant;
    private int result;

    void Start()
    {
        fireGunRef = FindObjectOfType<fireGun>();
        playerConRef = FindObjectOfType<PlayerController>();
        enemySpawnRef = FindObjectOfType<EnemySpawn>();
        enemyHealth = 2;
        enemMaterial = enemySpawnRef.enemyMaterialName;
    }

    
    void Update()
    {
        CheckResistance();

        if(enemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            if(resistant == false)
            {
                enemyHealth -= 1;
            }
            Destroy(other.gameObject);
        }
    }

    void CheckResistance()
    {
        if(playerConRef.heldWeapon != null)
        {
            heldWpn = playerConRef.heldWeapon;
            heldWeaponTag = heldWpn.tag;
            result = enemMaterial.IndexOf(heldWeaponTag, 0, enemMaterial.Length);
            if(result != -1)
            {
                resistant = false;
            }
            else{
                resistant = true;
            }
        }
    }
}