using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffRange : MonoBehaviour
{ //public AudioClip sound;
public static event HandleCollectBuff OnCollectBuff;
public delegate void HandleCollectBuff();
   
    
    void OnTriggerEnter2D(Collider2D hitInfo) { 
        
        fireBullet fireBullet=hitInfo.GetComponent<fireBullet>();
     if(fireBullet!=null){
       fireBullet.addRange();
         Debug.Log("OK++");
           // AudioManager.instance.playClip(sound);
           
        Destroy(gameObject);
        }} 


    }
    

    

