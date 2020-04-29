using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canPickUp;
    private GameObject player;
    private int health;
    private Transform hand;
    public GameObject lastInMit;
    public bool holdingWeapon;
    public GameObject heldWeapon;
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
        Debug.Log($"lastInMit = {lastInMit}");
        Debug.Log($"heldWeapon = {heldWeapon}");
        if(canPickUp && Input.GetKeyDown(KeyCode.Q))
        {
            PickUp();
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
