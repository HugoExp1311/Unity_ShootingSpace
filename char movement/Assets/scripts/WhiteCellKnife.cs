using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCellKnife : MonoBehaviour
{  Transform target; Vector3 spin; 
    public GameObject whitecell;
[SerializeField]private float spinSpeed=3f,knifeDamage=5f;
   public EnemyClass enemyClass;
    private void Start()
    {   
        target=whitecell.transform;
        spin= new Vector3(0,0,20);
        knifeDamage=enemyClass.damage;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.RotateAround(target.position,spin,spinSpeed);
    }
        void OnTriggerEnter2D(Collider2D hitInfo) {
        healthMain health= hitInfo.GetComponent<healthMain>();
        if(health != null){
            health.TakeDamage(knifeDamage);
            
        }}
        



    }

