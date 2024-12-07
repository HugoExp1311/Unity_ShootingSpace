using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using HutongGames.PlayMaker.Actions;
using Unity.VisualScripting;

public class shoot : MonoBehaviour
{
     public enum BulletTypes { Normal, Aoe, Vamp}
     public BulletTypes bulletType = BulletTypes.Normal; // option in default
    //will be buffed in another script :
   [Header("Will be Buffed")]
   private float basespeed=5f;  private int  baseDamage=10;
    public float speed=0f; float bonusSpeed;
    public int damage=0; int bonusDamage; 
      float splashRadius = 5f; public float bonusSplash;
     
       [Header("Crit Dmg stuff")]
 
 
     float critDamage;
     int critChance=0; public int critMax=100;
     int vampChance=0; public int vampMax=100; int vampAmount;
      GameObject main;
      [SerializeField] private GameObject FloatingCrit, FloatingHeal, Explo; Transform target;
   
    public Rigidbody2D rb; Vector3 aoedir; public Vector3 originalScale;
    
     private void Awake()
    {
        originalScale = transform.localScale;
        
    }
    private void OnEnable() {  
         rb=GetComponent<Rigidbody2D>();
        // buff the variable from the only 1 firebullet script, get ref to this script 
        main=GameObject.FindWithTag("Player");
     bonusDamage = main.GetComponent<fireBullet>().bonusDamage; 
      bonusSpeed = main.GetComponent<fireBullet>().bonusSpeed; 
      bonusSplash = main.GetComponent<fireBullet>().bonusSplash;
      aoedir=main.GetComponent<fireBullet>().aoedirection;

        if(rb!=null){ switch (bulletType)
        {
            case BulletTypes.Normal:
            speed=basespeed*3+bonusSpeed;
             rb.velocity=transform.right*(speed);
              damage=baseDamage+bonusDamage;
                
                break;
             case BulletTypes.Aoe:
             speed=basespeed*5+bonusSpeed;
               rb.velocity = transform.right * speed;
               damage=baseDamage*2-baseDamage/2+bonusDamage; //15+bonus
                
                break;
            case BulletTypes.Vamp:
            speed=basespeed*1.5f+bonusSpeed;
             rb.velocity=aoedir*(speed);
                 damage=baseDamage/2+bonusDamage-2; //3+bonus
                break;     
        
                
        } }
        Invoke("Disable",2f);
    }
     void Start() {
        rb=GetComponent<Rigidbody2D>();
        
        
        switch (bulletType)
        {
            case BulletTypes.Normal:
            
             rb.velocity=transform.right*(basespeed*3+bonusSpeed);
             
                
                break;
             case BulletTypes.Aoe:
             rb.velocity=transform.right*(basespeed*5+bonusSpeed);
             

                
                break;
            case BulletTypes.Vamp:
             rb.velocity=aoedir*(basespeed*1.5f+bonusSpeed);
                

                break;     
        
                
        } }
        
      
    void Disable(){
        gameObject.SetActive(false);    
    }
    
     private void OnDisable() {
        
        CancelInvoke();
    }
     private void ShowDamage(string text, bool isCrit)
    {
        if (FloatingCrit)
        {
            Vector3 spawnPosition = transform.position+ new Vector3(8, -3, 0);
            GameObject prefab = Instantiate(FloatingCrit, spawnPosition, Quaternion.identity);

            TextMeshPro textMesh = prefab.GetComponentInChildren<TextMeshPro>();
            if (textMesh != null)
            {
                textMesh.text = text;
                if (isCrit)
                {
                    textMesh.color = Color.red; // Change color for critical hits
                }         
                else
                {
                    textMesh.color = Color.white; // Change color for critical hits
                }
               
            }
        }
    }
     private void ShowHeal(string text, bool isHeal)
    {
        if (FloatingHeal)
        {
            target=GameObject.FindWithTag("Player").transform;
            Vector3 spawnPosition = target.position+ new Vector3(10, -1, 0);
            GameObject prefab = Instantiate(FloatingHeal, spawnPosition, Quaternion.identity);

            TextMeshPro textMesh = prefab.GetComponentInChildren<TextMeshPro>();
            if (textMesh != null)
            {
                textMesh.text = text;
                if (isHeal)
                {
                    textMesh.color = Color.green; // Change color for critical hits
                }
               
            }
        }
    }
    
     void OnTriggerEnter2D(Collider2D hitInfo) {   //handle COLLISION when the bullet hit any target
     
        IEnemy enemy = hitInfo.GetComponent<IEnemy>();
        if(enemy != null){
            switch (bulletType)
        {
            case BulletTypes.Normal:
            //damage+=baseDamage;
            
            ApplyDamage(enemy);
                
                break;
             case BulletTypes.Aoe:
            //damage+=baseDamage*2;

              DealAoE();
            ApplyDamage(enemy);
                
                break;
            case BulletTypes.Vamp:
            //damage+=baseDamage/2;
            Vamp();
            ApplyDamage(enemy);
                
                break;     
        
                
        } 
       
             Disable();
        }}
        void ApplyDamage(IEnemy enemy){
            int rand=Random.Range(1,100);
             if(critChance>=rand||critChance==critMax){ //(luck || guarantee crit++ to 100 will crit)
            critDamage=damage*2-1;
            enemy.TakeDamage(critDamage);
            ShowDamage(critDamage.ToString(),true);
            critChance=0;
            
           }
           else{
                
                enemy.TakeDamage(damage);
                ShowDamage(damage.ToString(),false);
               // Debug.Log("dmg="+ damage);
                critChance++;
                
            }
          
        }
       private void Vamp()
{
    vampAmount = baseDamage / 10 + bonusDamage;
    int rand = Random.Range(0, 100);
// Gameobject main chu ko phai public Gameobjet main, xong roi nho ghi dong duoi nay
    main = GameObject.FindGameObjectWithTag("Player"); 
    
    
    if (vampChance >= rand || vampChance == vampMax)
    {
        healthMain healthComponent = main.GetComponent<healthMain>();
        if (healthComponent != null)
        {
            healthComponent.Heal(vampAmount);
            ShowHeal(vampAmount.ToString(), true);
        }
       
        vampChance = 0;
    }
    else
    {
        vampChance++;
        Disable();
    }
}
         private void DealAoE()
    {
        // Find all enemies within the splash radius
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, splashRadius);

       foreach (Collider2D enemyCollider in enemies)
        {
            IEnemy enemy = enemyCollider.GetComponent<IEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage((baseDamage+damage)/1.5f);
            }
        }
// Instantiate explosion effect and scale it based on the splash radius
    GameObject explosion = Instantiate(Explo, transform.position, Quaternion.identity);
    explosion.transform.localScale = new Vector3(splashRadius*(3+bonusSplash), splashRadius*(3+bonusSplash), 1f);
        // Optionally, add some visual effects for the explosion
       
    }
  
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, splashRadius);
    }
}