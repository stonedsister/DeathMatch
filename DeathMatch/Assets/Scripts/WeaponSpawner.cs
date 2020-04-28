using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public List<string> weaponNames;
    public List<GameObject> rifles;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRifle());
    }

    IEnumerator SpawnRifle(){
        while(true){
            GameObject newGun = Instantiate(rifles[Random.Range(0, rifles.Count)], this.transform.position, this.transform.rotation);
            newGun.name = weaponNames[Random.Range(0, weaponNames.Count)];
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



