using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBullet : MonoBehaviour //Ko dung nua
{    bool isPoison = false;
    [SerializeField] private float poisonDamage = 10f, waitPoison = 5f, poisonDuration=3f;
    float index = 0;
    float nextDamageTime = 5f;
    public float speed=5f; 

    [SerializeField] private float damage; 
    public Rigidbody2D rb;
    public EnemyClass enemyClass; public List<int> stack=new List<int>();
    private void OnEnable() {
        if(rb!=null){ rb.velocity=new Vector3(0,-1,0)*speed;}
        Invoke("Disable",6f);
    }
     void Start() {
        rb.GetComponent<Rigidbody2D>();
        damage=enemyClass.damage;
        healthMain health=GetComponent<healthMain>();
        }
        
        
    void Disable(){
        gameObject.SetActive(false);    
    }
    
     private void OnDisable() {
        CancelInvoke();
    }
   
       
    
    void OnTriggerEnter2D(Collider2D hitInfo) {
        healthMain health = hitInfo.GetComponent<healthMain>();
        if (health != null)
        {
            health.TakeDamage(damage*.5f);
           StartCoroutine(Poison());
        } Disable();
    }

    IEnumerator Poison()
    { healthMain health=FindObjectOfType<healthMain>();
        /*while(stack.Count>0){
            for(int i=0;i<stack.Count;i++){
                stack[i]--;
            } health.TakeDamage(1f);
            stack.RemoveAll(i=>i==0);
        }*/
        while(index<nextDamageTime){
            health.TakeDamage(1f);
            yield return new WaitForSeconds(poisonDuration);
            index++;
        } 
            yield return new WaitForSeconds(waitPoison);
        }
        /*public void ApplyPoison(int poison){
            if(stack.Count<=0){
                stack.Add(poison);
                StartCoroutine(Poison());
            }
            else{
                stack.Add(poison);
            }
        }*/
    }

     
   
