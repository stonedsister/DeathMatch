using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> spawnPoints;
    public List<Material> gradients;
    public Material currentMaterial;
    public string enemyMaterialName;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            GameObject spawnedEnemy = Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position, this.transform.rotation);
            spawnedEnemy.GetComponent<Renderer>().material = gradients[Random.Range(0, gradients.Count)];
            currentMaterial = spawnedEnemy.GetComponent<Renderer>().material;
            enemyMaterialName = spawnedEnemy.GetComponent<Renderer>().material.name;

            spawnedEnemy.AddComponent<EnemyController>();
            yield return new WaitForSeconds(3f);
        }
    }
}
