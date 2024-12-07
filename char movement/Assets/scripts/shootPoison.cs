using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class shootPoison : MonoBehaviour
{   
    public float speed=5f; 
    [SerializeField] private float damage; 
    public Rigidbody2D rb;
    public EnemyClass enemyClass;
     private float totaltime=0;
    [SerializeField] private float poisonDmg=.2f, maxtime=1;
    private void OnEnable() {
        if(rb!=null){ rb.velocity=new Vector3(0,-1,0)*speed;}
        Invoke("Disable",3f);
    }
     void Start() {
        rb.GetComponent<Rigidbody2D>();
        rb.velocity=new Vector3(0,-1,0)*speed;
        damage=enemyClass.damage;
        }
        
        
    void Disable(){
        gameObject.SetActive(false);    
    }
    
     private void OnDisable() {
        CancelInvoke();
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo) {
        healthMain health= hitInfo.GetComponent<healthMain>();
        totaltime+=Time.deltaTime;
        if(health != null){
            health.TakeDamage(poisonDmg);
            if(totaltime>maxtime ){
               
               // health.health-=poisonDmg;

           totaltime=0; 
           Disable(); 
        }//Disable();
        }
    }
    }
     
   
