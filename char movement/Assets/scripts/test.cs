using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class test : MonoBehaviour
{
     LineRenderer lineRenderer;
    public GameObject line;
    public Transform startPoint;
   [SerializeField] private float damage;
   public EnemyClass enemyClass;  public AudioClip sound;  bool isShoot;
   float timer=0f;  float spawn=1f; public GameObject Ray;
     public LayerMask laserLayerMask; 

   /* void Start()
    {
        // Initialize the Line Renderer component
        lineRenderer=gameObject.GetComponent<LineRenderer>();
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;

       
        if (startPoint != null)
        {
            lineRenderer.SetPosition(0, startPoint.position);
            lineRenderer.SetPosition(1, startPoint.position+startPoint.right*100);
        }
        else
        {
            Debug.LogError("Please assign start and end points in the inspector!");
        }
    }*/
    private void Awake() {
        lineRenderer=line.GetComponent<LineRenderer>();
    }
    private void Start() {
         
        damage= enemyClass.damage;
        
               // StartCoroutine(ShootLaser()); //nhay 10 cai
              

    }
    private void Update() {
      if(isShoot==FindObjectOfType<BigQuyen>().isShoot2){
      ShootLaser();}
    }
   
    public void LaserPhase1 (){

   StartCoroutine(ShootRay());

    }
    public void LaserPhase2() {
        //StartCoroutine(ShootRay());
       ShootLaser(); //nhay 10 cai

    }
    
   /*private void Update() {
        if(Input.GetKey(KeyCode.K)){ 
 //need to have stop condition like this or ienemurator if ya dont want it flash so fast u couldnt see shit
        
        //StartCoroutine(ShootRay()); //nhay den flash flash
       ShootRay();
    }
      
        

    }*/
   
     IEnumerator ShootRay(){ 
           
      // lineRenderer=gameObject.GetComponent<LineRenderer>();
    
        RaycastHit2D hitInfo = Physics2D.Raycast(startPoint.position,-startPoint.right,Mathf.Infinity, laserLayerMask);
          
            if(hitInfo){    Debug.Log(hitInfo.transform.name);
             Debug.Log("trung dich");
                healthMain healthMain=hitInfo.transform.GetComponent<healthMain>();
                  if(healthMain!=null){             
                    AudioManager.instance.playClip(sound);
                    healthMain.TakeDamage(69);
                    Debug.Log("hit laser");
                  }else{Debug.Log("co trung del");}
                
            lineRenderer.SetPosition(0,startPoint.position);
            lineRenderer.SetPosition(1,hitInfo.point);}
             
            else{ 
              
                lineRenderer.SetPosition(0,startPoint.position);
                lineRenderer.SetPosition(1,startPoint.position-startPoint.right*100);} 
                
                lineRenderer.enabled=true; //hien line moi khi ban
                yield return new WaitForSeconds(.1f); //doi 1 frame, ko phai cool down!!
                lineRenderer.enabled=false; //tat line di
               
            
            }


           private void ShootLaser()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(startPoint.position, -startPoint.right, Mathf.Infinity, laserLayerMask);

        if (hitInfo)
        {
            healthMain healthMain = hitInfo.transform.GetComponent<healthMain>();
            if (healthMain != null)
            {
                AudioManager.instance.playClip(sound);
                healthMain.TakeDamage(.5f);
            }

            lineRenderer.SetPosition(0, startPoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, startPoint.position);
            lineRenderer.SetPosition(1, startPoint.position - startPoint.right * 100);
        }
    }

            }
            
            
            
    