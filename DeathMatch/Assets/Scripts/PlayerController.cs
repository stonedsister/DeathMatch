using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canPickUp;
    private GameObject player;
    private int health;
    private Transform hand;
    public GameObject lastTouchedWeapon;
    public bool holdingWeapon;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        player = this.gameObject;
        holdingWeapon = false;
        canPickUp = false;
        hand = this.transform.GetChild(0).GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(canPickUp)
        {
            PickUp();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.CompareTag("earth") ||
            other.gameObject.CompareTag("wind") ||
            other.gameObject.CompareTag("water") ||
            other.gameObject.CompareTag("fire") )
        {
            lastTouchedWeapon = other.gameObject;
            canPickUp = true;
        }
    }

    void PickUp(){
        lastTouchedWeapon.transform.SetParent(hand);
        lastTouchedWeapon.transform.localPosition = Vector3.zero;
        lastTouchedWeapon.transform.localRotation = Quaternion.identity;
    }
}
