using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private float speed=5f; 
    [SerializeField] private float damage=10f; 
     float critDamage;
     int critChance=0; int critMax=100;
     [SerializeField] private GameObject FloatingCrit;
    
    public Rigidbody2D rb;
    private void OnEnable() {
        if(rb!=null){ rb.velocity=transform.right*speed;}
        Invoke("Disable",2f);
    }
     void Start() {
        rb.GetComponent<Rigidbody2D>();
        
        rb.velocity=transform.right*speed;}
        
        
    void Disable(){
        gameObject.SetActive(false);    
    }
    
     private void OnDisable() {
        CancelInvoke();
    }
    void ShowDamage(string text){
  if(FloatingCrit){
    GameObject prefab=Instantiate(FloatingCrit,transform.position+new Vector3(1,0,0)*4f,Quaternion.identity); 
    //set postion for gameobject
    text=prefab.GetComponentInChildren<TextMesh>().text;    
    //set gameobject as crit text
  } 
}
    
     void OnTriggerEnter2D(Collider2D hitInfo) {   //handle COLLISION when the bullet hit any target
        IEnemy enemy = hitInfo.GetComponent<IEnemy>();
        if(enemy != null){
            int rand=Random.Range(1,100);
            if(critChance<critMax && critChance<rand){
                enemy.TakeDamage(damage);
                critChance++;
                Disable();
            }
           if(critChance>=rand||critChance==critMax){
            critDamage=damage*1.5f;
            enemy.TakeDamage(critDamage);
            ShowDamage(critDamage.ToString());
            critChance=0;
            Disable();
           } Disable();
        }}
}
