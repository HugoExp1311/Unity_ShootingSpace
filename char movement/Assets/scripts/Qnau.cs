using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qnau : MonoBehaviour,IEnemy

{ [SerializeField] private  float spin=2f;
public bool isSplit=false;
  public EnemyClass enemyClass;

public Rigidbody2D rb;
[SerializeField] private float damage = 30f;
[SerializeField] private  float healthMax=50f;
   [SerializeField] private float health;
   //public float BarHealthCurrent=>health;
   //public float BarHealthMax=>healthMax;
 
public float deadZone=-15f;
private Vector3 smallScale; 
  [SerializeField] private int expAmount; 
   Vector2 moveDir;  Transform target;

    private void Start() {
        smallScale= new Vector3(.4f,.4f);
        health=healthMax;
        rb.GetComponent<Rigidbody2D>();
        expAmount=enemyClass.exp;
 target=GameObject.FindWithTag("Player").transform;
  Vector3 direction=(target.position-transform.position).normalized;
     float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Deg2Rad;
     moveDir=direction;  
      rb.velocity=new Vector2(moveDir.x,moveDir.y)*5;
    
    }
    


    // Update is called once per frame
    private void Update()
    {  
    transform.Rotate(new Vector3(0,0,20)*spin,Space.World);
     //randDir=new Vector3(Random.Range(-2,2),Random.Range(-2,2));
     //float fallAngle=Mathf.Atan2(randDir.y,randDir.x)*Mathf.Rad2Deg-90f;  //Pattern: take the angle
     //rb.rotation=fallAngle;
    Destroy(gameObject,6f);
    
 }
    /* private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.TryGetComponent<healthMain>(out healthMain healthMain)){
            healthMain.TakeDamage(damage);
            Destroy(gameObject);
        }
        if(collision.gameObject.name=="BORDER LINE"){
            Vector3 moveDir= new Vector3(0,1).normalized;
 transform.position+= moveDir * 5* Time.deltaTime;
        }
         if(gameObject.transform.position.y<deadZone){Destroy(gameObject);}
    }   
    */

    public  void TakeDamage(float damage){
  health-=damage;
  
    if (health<=0f){ health=0f;
    if (health==0f){

        if (isSplit==false){  //Split into 2 smaller gameobject DO NOT DESTROY ANY OBJECT
       isSplit=true;
       for(int i=0;i<2;i++){
        GameObject newgameObject= Instantiate(gameObject,transform.position+new Vector3(Random.Range(-2,2),Random.Range(-1,0))*2f,transform.rotation);
        newgameObject.transform.localScale=smallScale;
     
        }
        }

        if(isSplit==true){ for(int i=0;i<2;i++)   //destroy 2 gameobject which has been instantiated after split
            Destroy(gameObject); 
    }}}}

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        healthMain health= hitInfo.GetComponent<healthMain>();
        if(health != null){
            health.TakeDamage(damage);
        }} 

}




     
   

