using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireProjectile : MonoBehaviour
{   [SerializeField] private int num;
    public EnemyClass enemyClass;
    public Transform[] FirePoint;
public GameObject Bullet;
float timer=0f;  float spawn=2f;
float timer2=0f; float spawn2=1f;

private void Start() {
   num = enemyClass.firePoints;
}

   private void SpawnBullet(){
    if(timer2<spawn2){timer2+=.25f;}
        else{
            for(int i=0;i<FirePoint.Length;i++){
          Bullet= projectilePool.current.GetPool(); //make ref
            if(Bullet==null)return;
            Bullet.transform.position=FirePoint[i].position;
            Bullet.transform.rotation=FirePoint[i].rotation;
            Bullet.SetActive(true);} 
            timer2=0f;
        }}

    // Update is called once per frame
    void Update()
    {      
        if(timer<spawn){timer += .25f;}
             else{SpawnBullet();
             timer=0f;}
    }
   
   
}
