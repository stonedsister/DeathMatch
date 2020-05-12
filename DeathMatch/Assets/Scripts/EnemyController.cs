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
    }

    
    void Update()
    {
        if(enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            playerConRef.score += 10;
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
                playerConRef.score += 10;
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
            if(result == -1)
            {
                resistant = true;
            }
            else{
                resistant = false;
            }
        }
        
    }
}
