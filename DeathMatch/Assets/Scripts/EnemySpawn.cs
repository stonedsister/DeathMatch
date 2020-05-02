using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<GameObject> spawnPoints;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position, this.transform.rotation);
            yield return new WaitForSeconds(3f);
        }
    }
}
