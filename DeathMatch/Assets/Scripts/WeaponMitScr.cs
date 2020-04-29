using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMitScr : MonoBehaviour
{
    public GameObject mit;
    public bool pickedUp;
    public bool mitWeaponized;
    public GameObject players;
    public Transform heldWeaponAsChild;
    public GameObject heldWeapon;
    
    void Start()
    {
        mit = this.gameObject;
        mitWeaponized = false;
        heldWeaponAsChild = players.transform.GetChild(0).GetChild(0);
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
        }

        if(other.gameObject.CompareTag("player"))
        {
            Debug.Log("Player entered the mit");
            Debug.Log($"Hand chlid = {heldWeaponAsChild}");
            if(heldWeaponAsChild != null)
            {
                foreach(Transform heldWeaponAsChild in transform)
                {
                    Destroy(heldWeaponAsChild);
                }
                Debug.Log("Weapon destroyed in mit");
                // Destroy(heldWeaponAsChild);
                
            }
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
