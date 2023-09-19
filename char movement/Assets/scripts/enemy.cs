using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour,IEnemy
{ public GameObject Bomb;
  public GameObject Coin;
  [SerializeField] private int expAmount;
  public EnemyClass enemyClass;
    [SerializeField] private float healthMax;
   [SerializeField] private float health;
   //public float BarHealthCurrent=>health;
   //public float BarHealthMax=>healthMax;

   [SerializeField] HP_Enemy1 hPbar;
 
private void Start() {
  healthMax=enemyClass.health;
  expAmount=enemyClass.exp;
  health=healthMax;
  hPbar=GetComponentInChildren<HP_Enemy1>();
  hPbar.UpdateHealthBar(health,healthMax);
}
public  void TakeDamage(float damage){
  hPbar.UpdateHealthBar(health,healthMax);
  health-=damage;
    if (health==(healthMax/2) || health==(healthMax/2)+.5f || health==(healthMax/2)-.5f){ 
      Instantiate(Bomb,transform.position,Quaternion.identity); }
    if (health<=0f){ health=0f;
    if (health==0f){
      ExpManager.instance.AddExp(expAmount);
        Instantiate(Coin,transform.position,Quaternion.identity);
        Destroy(gameObject);
        }
    }}
      }


    
