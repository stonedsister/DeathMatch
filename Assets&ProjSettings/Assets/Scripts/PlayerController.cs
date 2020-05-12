using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private GameObject player;
    public GameObject lastInMit;
    public GameObject heldWeapon;
    public GameObject pausedCan;
    
    public bool canPickUp;
    public bool holdingWeapon;
    public bool paused;

    public int health;
    public int score;
    
    private Transform hand;

    private Rigidbody heldWeaponRB;

    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI healthTMP;
    public TextMeshProUGUI ammoTMP;
    public TextMeshProUGUI weaponNameTMP;

    public fireGun fireGunRef;


    
    
    void Start()
    {
        health = 5;
        player = this.gameObject;
        holdingWeapon = false;
        canPickUp = false;
        hand = this.transform.GetChild(0).GetChild(0);
        paused = true;
        score = 0;
        pausedCan.gameObject.SetActive(false);
    }

    
    void Update()
    {
        scoreTMP.text = $"{score}";
        healthTMP.text = $"Health -> {health}";
        

        if(holdingWeapon)
        {
            ammoTMP.text = $"Ammo = {fireGunRef.ammoCount}";
            weaponNameTMP.text = heldWeapon.name;
        }
        else
        {
            ammoTMP.text = $"Ammo = 0";
        }

        if(canPickUp && Input.GetMouseButtonDown(1))
        {
            if(holdingWeapon != true)
            {
                PickUp();
            }
            else
            {
                PickUp();
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Paused();
            paused = !paused;
        }
        
        if(holdingWeapon && Input.GetKeyDown(KeyCode.E))
        {
            Drop();

        }

        if(health <= 0)
        {
            SceneManager.LoadScene(4);
        }
        if(score >= 20)
        {
            SceneManager.LoadScene(3);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("proximity"))
        {
            canPickUp = true;
        }

        if(other.gameObject.CompareTag("enemy"))
        {
            health -= 1;
        }
    }

    void PickUp()
    {
        Destroy(heldWeapon);
        fireGunRef = FindObjectOfType<fireGun>();
        heldWeapon = lastInMit;
        lastInMit.transform.SetParent(hand);
        lastInMit.transform.localPosition = Vector3.zero;
        lastInMit.transform.localRotation = Quaternion.identity;

        holdingWeapon = true;

        heldWeaponRB = heldWeapon.GetComponent<Rigidbody>();
        heldWeaponRB.constraints = RigidbodyConstraints.FreezeAll;
    }

    void Drop(){
        holdingWeapon = false;
        Destroy(heldWeapon);
        weaponNameTMP.text = "";
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("proximity"))
        {
            canPickUp = false;
        }
    }

    void Paused()
    {
        if(paused)
        {
            Time.timeScale = 0;
            pausedCan.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else{
            Time.timeScale = 1;
            pausedCan.gameObject.SetActive(false);
        }
    }
}
