using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherry : MonoBehaviour
{   float healAmount=50f; public Rigidbody2D rb;
public AudioClip sound;
private void Start() {
    rb.GetComponent<Rigidbody2D>();
        
        rb.velocity=new Vector3(0,-1,0)*4;
}
   
   void OnTriggerEnter2D(Collider2D hitInfo) {
    healthMain health=hitInfo.GetComponent<healthMain>();
        if(health!=null ){ 
            AudioManager.instance.playClip(sound);
            health.Heal(healAmount);
            Destroy(gameObject);
        }}
}
