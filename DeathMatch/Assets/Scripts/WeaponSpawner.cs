using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public List<string> weaponNames;
    public List<GameObject> rifles;
    public WeaponMitScr check;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRifle());
    }

    

    IEnumerator SpawnRifle(){
        while(true){
            GameObject newGun = Instantiate(rifles[Random.Range(0, rifles.Count)], this.transform.position, this.transform.rotation);
            newGun.name = weaponNames[Random.Range(0, weaponNames.Count)];
            yield return new WaitForSeconds(3f);            
            
            Debug.Log("Before if");
            if(check.mitWeaponized == true)
            {
                Destroy(newGun);
                Debug.Log("New gun destroyed");
            }
            else{
                Debug.Log("IN else");
            }
            check.mitWeaponized = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



