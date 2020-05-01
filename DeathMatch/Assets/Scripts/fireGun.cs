﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireGun : MonoBehaviour
{
    public Rigidbody bulletPreFab;
    public Transform bulletSpawn;
    public PlayerController weaponCheck;


    void Start()
    {
        weaponCheck = FindObjectOfType<PlayerController>();
        bulletSpawn = this.GetComponent<Transform>().GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{weaponCheck.heldWeapon}");
        Debug.Log(weaponCheck.lastInMit);
        if(Input.GetMouseButtonDown(0) && this.gameObject == weaponCheck.heldWeapon)
        {
            Debug.Log("Shoot called");
            Shoot();
        }
        
    }

    void Shoot()
    {
        Rigidbody bullet = Instantiate(bulletPreFab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.AddRelativeForce(Vector3.forward * 50f, ForceMode.Impulse);   
    }
}
