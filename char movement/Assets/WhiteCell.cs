using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics; //math vs random
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random; //math vs random

public class WhiteCell : MonoBehaviour,IEnemy
{[SerializeField] private int expAmount;
public static event Action Ondeath;
public BossHandle bossHandle;
  public EnemyClass enemyClass;
  //public GameObject spawnerPrefab;

  [Header("Health and Coin")]
   [SerializeField] private float healthMax;
   [SerializeField] private float health;
   //public float BarHealthCurrent=>health;
   //public float BarHealthMax=>healthMax;
   [SerializeField] private int numKnives=3;
   [SerializeField] HP_Enemy1 hPbar;
    public GameObject Coin;

    [Header("Movement")]
    Transform target; Vector2 MoveDirection; Rigidbody2D rb; 
    [SerializeField] private float moveSpeed=5f,dashSpeed=10f,dashDuration=1f,DashCooldown=2f;
    float timer=0f,spawn=2f;
    public TrailRenderer trailRenderer;
    public Vector3 randDir;
  public bool isPhase2=false,isDash=false,isTrap=false,canDash=false;
    
    private void Awake() {
      rb=GetComponent<Rigidbody2D>();
      hPbar=GetComponentInChildren<HP_Enemy1>();
       
    }
    private void Start() {
  healthMax=enemyClass.health;
  health=healthMax;
  hPbar.UpdateHealthBar(health,healthMax);
  target=GameObject.FindWithTag("Player").transform;
  randDir=new Vector3(Random.Range(-5,5),Random.Range(-5,5));
}
 private void Update() {
          Vector3 direction=(target.position-transform.position).normalized;  //chase player
          float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
          MoveDirection=direction;

          if(isDash){return;}
        }
private void FixedUpdate() {
  if(isDash){return;}
  if(timer<spawn){timer+=.5f;}
  else{ 
  rb.velocity=new Vector2(MoveDirection.x,MoveDirection.y)*moveSpeed;
  timer=0f;
  }
  if(isPhase2&&canDash){
   
  StartCoroutine(Dashing());}
  
}
IEnumerator Dashing(){
  canDash=false;
  isDash=true;
   rb.velocity=new Vector2(MoveDirection.x*dashSpeed,MoveDirection.y*dashSpeed);
  //rb.AddForce(MoveDirection*dashSpeed);
  trailRenderer.emitting=true;
  yield return new WaitForSeconds(dashDuration); //dash duration
  trailRenderer.emitting=false;
 isDash=false; 
 yield return new WaitForSeconds(DashCooldown); //dash cd
 canDash=true;
}

public  void TakeDamage(float damage){
  health-=damage;
  hPbar.UpdateHealthBar(health,healthMax);
  if (health<=(healthMax/2)){ isPhase2=true;
   // Check if the reference is valid
            //spawnerPrefab.SetActive(true);
            }
    if (health<=0f){ health=0f;
    if (health==0f){
      bossHandle.Died();
            //spawnerPrefab.SetActive(false);
       // OnDeath?.Invoke();
      ExpManager.instance.AddExp(expAmount);
      Instantiate(Coin,transform.position+randDir,Quaternion.identity);}
        Destroy(gameObject);
        }}
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.TryGetComponent<healthMain>(out healthMain healthMain)){
            healthMain.TakeDamage(50);
        }}  

//public void SecondPhase(){

//}

      }

