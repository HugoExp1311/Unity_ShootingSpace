using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_waves : MonoBehaviour
{
    [SerializeField] private float waveDelay = 3f;
    public GameObject[] spawnerPrefab;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {   
        foreach (GameObject spawner in spawnerPrefab)
        {   
            // Activate the spawner
            spawner.SetActive(true);
            // Wait until all enemies are spawned and killed
            enemy_spawn enemySpawnComponent = spawner.GetComponent<enemy_spawn>();
          enemySpawnComponent.Spawner();
            yield return new WaitUntil(() => !enemySpawnComponent.isSpawn); //wait until isSpawn=false;

            // Deactivate the spawner
            spawner.SetActive(false);

            // Delay between waves
            yield return new WaitForSeconds(waveDelay);
        }

        // Deactivate this object when all waves are done
        gameObject.SetActive(false);
    }
}
