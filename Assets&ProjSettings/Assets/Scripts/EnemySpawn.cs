using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemies;
    public List<GameObject> spawnPoints;
    public List<Material> gradients;
    public List<Material> earColors;
    public Material currentMaterial;
    public string enemyMaterialName;
    public GameObject enemyEar;
    public GameObject enemyEar1;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            GameObject spawnedEnemy = Instantiate(enemies, spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position, this.transform.rotation);
            enemyEar = spawnedEnemy.transform.GetChild(0).gameObject;
            enemyEar1 = spawnedEnemy.transform.GetChild(1).gameObject;
            enemyEar.GetComponent<Renderer>().material = earColors[Random.Range(0, earColors.Count)];
            do
            {
                enemyEar1.GetComponent<Renderer>().material = earColors[Random.Range(0, earColors.Count)];
            }while(enemyEar1.GetComponent<Renderer>().material == enemyEar.GetComponent<Renderer>().material);

            spawnedEnemy.GetComponent<Renderer>().material = gradients[Random.Range(0, gradients.Count)];
            currentMaterial = spawnedEnemy.GetComponent<Renderer>().material;
            enemyMaterialName = spawnedEnemy.GetComponent<Renderer>().material.name;
            spawnedEnemy.AddComponent<EnemyController>();
            yield return new WaitForSeconds(3f);
        }
    }
}
