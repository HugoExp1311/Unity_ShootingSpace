using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour,IEnemy
{ public GameObject Bomb;  public GameObject Cherry; 
  public GameObject Coin; public GameObject Explo; public AudioClip ExploSound;
  [SerializeField] private int expAmount;
  public EnemyClass enemyClass; 
    [SerializeField] private float healthMax;
   [SerializeField] private float health;
   //public float BarHealthCurrent=>health;
   //public float BarHealthMax=>healthMax;

   [SerializeField] HP_Enemy1 hPbar;

   // Implementing the Colors property from IEnemy interface


private void Start() {
  
  healthMax=enemyClass.health;
expAmount=enemyClass.exp;
  health=healthMax;
  hPbar=GetComponentInChildren<HP_Enemy1>();
  hPbar.UpdateHealthBar(health,healthMax);
   //Cherry = Resources.Load<GameObject>("Prefabs/CherryHeal");
}
public  void TakeDamage(float damage){
  hPbar.UpdateHealthBar(health,healthMax);
  health-=damage;
    if (health==(healthMax/2) || health==(healthMax/2)+.5f || health==(healthMax/2)-.5f){ 
      Instantiate(Bomb,transform.position,Quaternion.identity); }
    if (health<=0f){ health=0f;
    if (health==0f){
      ExpManager.instance.AddExp(expAmount);

       int rand=Random.Range(1,5);
             if(rand%3==0){ //(luck || guarantee crit++ to 100 will crit)
            Instantiate(Cherry,transform.position,Quaternion.identity);}
        Instantiate(Coin,transform.position,Quaternion.identity);
      GameObject explosion=  Instantiate(Explo,transform.position, Quaternion.identity);
      explosion.transform.localScale= new Vector3(1,3,1);
        AudioManager.instance.playClip(ExploSound);
        Destroy(gameObject);
        }
    }}


    
      }


    
