using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherry : MonoBehaviour
{   float healAmount=10f;
public AudioClip sound;

   
   void OnTriggerEnter2D(Collider2D hitInfo) {
    healthMain health=hitInfo.GetComponent<healthMain>();
        if(health!=null ){ 
            AudioManager.instance.playClip(sound);
            health.Heal(healAmount);
            Destroy(gameObject);
        }}
}
