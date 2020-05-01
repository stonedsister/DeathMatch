using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireGun : MonoBehaviour
{
    public Rigidbody bulletPreFab;
    public Transform bulletSpawn;


    void Start()
    {
        bulletSpawn = this.GetComponent<Transform>().GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        Rigidbody bullet = Instantiate(bulletPreFab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.AddRelativeForce(Vector3.forward * 50f, ForceMode.Impulse);   
    }
}
