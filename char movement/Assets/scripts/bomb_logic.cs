using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_logic : MonoBehaviour
{   [SerializeField] private float speed=2f; 
    [SerializeField] private float damage=1000f; 
    public Rigidbody2D rb;
    public GameObject explo;
    // Start is called before the first frame update
    void Start()
    {    rb.GetComponent<Rigidbody2D>();
        
        rb.velocity=new Vector3(0,-1,0)*speed;
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {
        healthMain health= hitInfo.GetComponent<healthMain>();
        if(health != null){ health.TakeDamage(damage);
            Destroy(gameObject);}
        }
   
}
