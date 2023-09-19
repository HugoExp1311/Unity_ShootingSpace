using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeTrap : MonoBehaviour
{ [SerializeField] private float spin=.2f, knifeDamage=5f;
    
    private void OnTriggerEnter2D(Collider2D other) {
        healthMain health=other.GetComponent<healthMain>();
        if(health!=null){
            health.TakeDamage(knifeDamage);
        }
    }
    
}
