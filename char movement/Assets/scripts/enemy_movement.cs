using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{ float timer=10f; float count=0f; 
public float speed=1f; 
public float deadZone=-15f;
//public Rigidbody2D rb;
 Transform[] target;
 [SerializeField] float maxDistance,range;
Vector3 waypoint;

private void Start() {
    //rb.GetComponent<Rigidbody2D>();
    setNewDestination();
}
private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.TryGetComponent<healthMain>(out healthMain healthMain)){
            healthMain.TakeDamage(1000);
        }}

private void setNewDestination(){
    waypoint=new Vector3(Random.Range(-maxDistance,maxDistance),Random.Range(-maxDistance,maxDistance));
}

void Update(){ Vector3 moveDir= new Vector3(0,-1);
 


 
 if(transform.position.y>4){
    transform.position+=moveDir*speed*Time.deltaTime;} 
    else{
    if(count<=timer){
        count+=0.005f; 
        transform.position= Vector2.MoveTowards(transform.position,waypoint,speed*Time.deltaTime);
        if(Vector2.Distance(transform.position,waypoint)<range){
            setNewDestination();
        }
          
    }
    else{ transform.position+=moveDir*speed*Time.deltaTime;
       
          //  Vector3 direction=(target.position-transform.position).normalized;
            /////////float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
            /////////rb.rotation=angle;
    //   transform.position+=direction*speed*Time.deltaTime;
    //    if(transform.position==target.position) do something
    }
 if(gameObject.transform.position.y<deadZone){Destroy(gameObject);}
    }}}

     
        

