using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject player;
    public GameObject lastInMit;
    public GameObject heldWeapon;
    
    public bool canPickUp;
    public bool holdingWeapon;

    private int health;
    
    private Transform hand;
    
    
    void Start()
    {
        health = 5;
        player = this.gameObject;
        holdingWeapon = false;
        canPickUp = false;
        hand = this.transform.GetChild(0).GetChild(0);
    }

    
    void Update()
    {
        Debug.Log($"Heldweapon = {heldWeapon}");
        if(canPickUp && Input.GetKeyDown(KeyCode.Q))
        {
            if(holdingWeapon != true)
            {
                PickUp();
            }
            else
            {
                Destroy(heldWeapon);
                PickUp();
            }
            
        }
        
        if(holdingWeapon && Input.GetKeyDown(KeyCode.E))
        {
            Drop();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("proximity"))
        {
            canPickUp = true;
        }
    }

    void PickUp()
    {
        heldWeapon = lastInMit;
        lastInMit.transform.SetParent(hand);
        lastInMit.transform.localPosition = Vector3.zero;
        lastInMit.transform.localRotation = Quaternion.identity;
        holdingWeapon = true;
    }

    void Drop(){
        holdingWeapon = false;
        Destroy(heldWeapon);
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("proximity"))
        {
            canPickUp = false;
        }
    }
}
