using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCoffee : MonoBehaviour
{ [SerializeField] int shieldAmount=3;
    void OnTriggerEnter2D(Collider2D hitInfo) {
    healthMain health=hitInfo.GetComponent<healthMain>();
        if(health!=null ){ 
            //AudioManager.instance.playClip(sound);
            health.AddShield(shieldAmount); 
            Destroy(gameObject);
        }}
}
