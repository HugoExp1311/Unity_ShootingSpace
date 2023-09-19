using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
   [SerializeField] private float spawnRate=1f;
    public GameObject[] enemyPrefab;
    public Transform[] enemySpawnPoint;
    public bool isSpawn=false;
    [SerializeField] private int numEnemy=6; //mot wave toi da 10 con
    [SerializeField] private const int maxEnemy=10; 
    
    void Start()
    {   
    //dialogManager=FindObjectOfType<DialogManager>();
       // StartCoroutine(waitForDialog());
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner(){ 
  
        WaitForSeconds wait= new WaitForSeconds(spawnRate);
        while(isSpawn && numEnemy<=maxEnemy && numEnemy>0){
            yield return wait;
            int randEnemy=Random.Range(0,enemyPrefab.Length);
            int randSpawnPoint=Random.Range(0,enemySpawnPoint.Length);
            GameObject enemy=enemyPrefab[randEnemy];
            Vector3 point=enemySpawnPoint[randSpawnPoint].position;
            Instantiate(enemy,point,transform.rotation);
        
            numEnemy--;
        }
         isSpawn=false;
         if(isSpawn==false){
          
            gameObject.SetActive(false);
    }}
}