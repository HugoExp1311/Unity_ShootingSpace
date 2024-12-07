using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
   [SerializeField] public float spawnRate=1f;
    public GameObject[] enemyPrefab;
    public Transform[] enemySpawnPoint;
    public bool isSpawn=false;// ban dau la false wtf deo hieu lam chac ngoai editor de true
    [SerializeField] public int numEnemy=6; //mot wave toi da 10 con
    [SerializeField] private const int maxEnemy=1000; 
    [SerializeField] private List<Transform> availableSpawnPoints;
    private List<GameObject> activeEnemies = new List<GameObject>();
    public string pathType; 
    
    void Start()
    {   
    //dialogManager=FindObjectOfType<DialogManager>();
       // StartCoroutine(waitForDialog());
        availableSpawnPoints = new List<Transform>(enemySpawnPoint);
      
      
//       pathType=enemyPrefab[0].GetComponent<PathType>().pathType.ToString();
       Debug.Log(pathType);
      //  if(pathType=="Down"){
      //      StartCoroutine(SpawnerDown());
      //  }
       // else{
        StartCoroutine(Spawner());
       // }
    }

    public IEnumerator Spawner(){ 
  
        WaitForSeconds wait= new WaitForSeconds(spawnRate);
        while(isSpawn && numEnemy<=maxEnemy && numEnemy>0){
            yield return wait;
            int randEnemy=Random.Range(0,enemyPrefab.Length);
            int randSpawnPoint=Random.Range(0,enemySpawnPoint.Length);
            GameObject enemyobj=enemyPrefab[randEnemy];
            Vector3 point=enemySpawnPoint[randSpawnPoint].position;

           GameObject enemy= Instantiate(enemyobj,point,transform.rotation);
          activeEnemies.Add(enemy); //them GameObject duoc instantiate vao list
            numEnemy--;
        }
       StartCoroutine(CheckEnemies()); //check xem activenemies.count==0 thi isSpawn=false;
        }

public IEnumerator SpawnerDown()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (isSpawn && numEnemy <= maxEnemy && numEnemy > 0)
        {
            yield return wait;

            if (availableSpawnPoints.Count == 0)
            {
                // Reset the list of available spawn points
                availableSpawnPoints = new List<Transform>(enemySpawnPoint);
            }

            int randEnemy = Random.Range(0, enemyPrefab.Length);
            int randSpawnIndex = Random.Range(0, availableSpawnPoints.Count);
            GameObject enemyobj = enemyPrefab[randEnemy];
            Vector3 spawnPoint = availableSpawnPoints[randSpawnIndex].position;

            // Remove the used spawn point from the list
            availableSpawnPoints.RemoveAt(randSpawnIndex);

          GameObject enemy=  Instantiate(enemyobj, spawnPoint, transform.rotation);
            activeEnemies.Add(enemy);
            numEnemy--;
        }

         StartCoroutine(CheckEnemies());
    }

private IEnumerator CheckEnemies()
    {
        while (true)
        {
            activeEnemies.RemoveAll(enemy => enemy == null); // Remove null entries from the list
            if (activeEnemies.Count == 0)
            {
                isSpawn = false;
                gameObject.SetActive(false);
                yield break; // Exit the coroutine
            }
            yield return new WaitForSeconds(spawnRate); // Check every second
        }
    }
}
