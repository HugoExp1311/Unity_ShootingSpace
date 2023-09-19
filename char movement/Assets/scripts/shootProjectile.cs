using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootProjectile : MonoBehaviour
{   
    public float speed=5f; 
    [SerializeField] private float damage; 
    public Rigidbody2D rb;
    public EnemyClass enemyClass;
    private void OnEnable() {
        if(rb!=null){ rb.velocity=new Vector3(0,-1,0)*speed;}
        Invoke("Disable",4f);
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
        if(health != null){
            health.TakeDamage(damage);
            Disable();
        }}
}
     
   
