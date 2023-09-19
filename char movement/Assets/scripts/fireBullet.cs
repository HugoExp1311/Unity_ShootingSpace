using System.Collections;
using System.Collections.Generic;
using UnityEngine; using CodeMonkey;
using CodeMonkey.Utils;

public class fireBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform FirePoint;
    public GameObject Ray;
    public LineRenderer lineRenderer;
    public GameObject Bullet;
    [SerializeField] private LayerMask layer;
 float timer=0f;  float spawn=3f; float rayDamage =30f;
 float timer2=0f; float spawn2=1f; public bool isShoot=true;
    public AudioClip sound;
    
    void Update()
    {    
            if(isShoot==true){
             if(timer<spawn){timer += .2f;}
             else{ 
                
                SpawnBullet();
             timer=0f;}}
        
    }
    private void FixedUpdate() {
           
        if(Input.GetKey(KeyCode.J)){ isShoot=false;
        
        StartCoroutine (ShootRay());}
        
    }
        IEnumerator ShootRay(){ 
        RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position,FirePoint.right,Mathf.Infinity,layer);
            if (timer<spawn){timer+=.1f; 
              lineRenderer.enabled=false;
               } //cooldown 3f;
            else{ 
            if(hitInfo){    
              AudioManager.instance.playClip(sound);
                    enemy enemy=hitInfo.transform.GetComponent<enemy>();
                if(enemy!=null){enemy.TakeDamage(rayDamage); 
                } Instantiate(Ray,hitInfo.point,Quaternion.identity); 
                
            lineRenderer.SetPosition(0,FirePoint.position);
            lineRenderer.SetPosition(1,hitInfo.point);}
             
            else{ 
              AudioManager.instance.playClip(sound);
                lineRenderer.SetPosition(0,FirePoint.position);
                lineRenderer.SetPosition(1,FirePoint.position+FirePoint.right*100);} 
                lineRenderer.enabled=true; //hien line moi khi ban
                yield return new WaitForSeconds(.02f); //doi 1 frame, ko phai cool down!!
                lineRenderer.enabled=false; //tat line di
                timer=0f;
            } isShoot=true;} 
        private void SpawnBullet(){
            if(timer2<spawn2){timer2 += .5f;}
             else{ 
            GameObject obj= objectPool.current.GetPool(); //make ref
            if(obj==null)return;
            obj.transform.position=FirePoint.position;
            obj.transform.rotation=FirePoint.rotation;
            obj.SetActive(true);
         timer2=0f;}}
//if(timer<spawn){timer += .2f;}else{Instantiate(gameObject,FirePoint.position,FirePoint.rotation);timer=0f;}
             
}

