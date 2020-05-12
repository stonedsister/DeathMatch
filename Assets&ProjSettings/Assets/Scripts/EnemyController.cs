using System.Collections;
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
    public GameObject enemEarRef;
    public GameObject enemEarRef1;
    public static bool resistant;
    private int result;

    void Start()
    {
        fireGunRef = FindObjectOfType<fireGun>();
        playerConRef = FindObjectOfType<PlayerController>();
        enemySpawnRef = FindObjectOfType<EnemySpawn>();
        enemyHealth = 2;
        enemMaterial = enemySpawnRef.enemyMaterialName;
        this.gameObject.tag = "enemy";
        enemEarRef = enemySpawnRef.enemyEar;
        enemEarRef1 = enemySpawnRef.enemyEar1;
    }

    
    void Update()
    {
        if(enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            playerConRef.score += 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            CheckResistance();
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
            if( enemEarRef.GetComponent<Renderer>().material.name == heldWpn.GetComponent<Renderer>().material.name || 
                enemEarRef1.GetComponent<Renderer>().material.name == heldWpn.GetComponent<Renderer>().material.name)
            {
                resistant = false;
            }
            else
            {
                resistant = true;
            }
        }
        
    }
}
