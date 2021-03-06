﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMitScr : MonoBehaviour
{
    public GameObject mit;
    public bool mitWeaponized;
    public Transform heldWeaponAsChild;
    public GameObject heldWeapon;
    public PlayerController weaponSet;
    
    
    void Start()
    {
        mit = this.gameObject;
        mitWeaponized = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("enemy") || !other.gameObject.CompareTag("player"))
        {
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.transform.position = this.gameObject.transform.position;
            mitWeaponized = true;
            weaponSet.lastInMit = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(!other.gameObject.CompareTag("enemy"))
        {
            mitWeaponized = false;
        }
    }
}
