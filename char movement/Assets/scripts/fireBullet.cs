using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using CodeMonkey;
using CodeMonkey.Utils;
using Unity.VisualScripting;
using System.Threading;


public class fireBullet : MonoBehaviour
{
    
    public Transform[] FirePoint;
        [SerializeField] private int num=6;
    public GameObject Ray;
    public LineRenderer lineRenderer;
    public GameObject Bullet;
    [SerializeField] private LayerMask layer;
 float timer=0f;  float spawn=1f; // apply rate for each bullet
  

 float timer2=0f; float spawn2=3f; //apply cooldown for bullet 
private float frequency = 4f; // For curve and zigzag paths How fast the bullet moves in the sine wave pattern
    private float magnitude = 2f; // For curve and zigzag paths How wide the sine wave is
  float rayDamage =30f; 
 public bool isShoot=true; 
 public float atkspd=0;  public int bonusDamage=0; public float bonusSpeed=0;  public float bonusSplash =0f;// atkspd=0.1f max=0.5f; 
    public AudioClip sound;
  public int directionState=0; public Vector3 aoedirection;
  public string bulletType; public int Poolnum = 30; 
  //public int directionState2=0;


//save and load

private void Start() {
   if(Bullet==null){
    Bullet=GameObject.Find("bullet1");
   } 
   bulletType= Bullet.GetComponent<shoot>().bulletType.ToString();
   Debug.Log(bulletType);
   switch(bulletType){
            case "Normal":
            Poolnum=120;
            break;
             case "Aoe":
           Poolnum=20;
            break;
             case "Vamp":
           Poolnum=50;
            break;
            default: Poolnum=30;
            break;
}
objectPool.current.InitializePool(Bullet, Poolnum); 
}
  void Update()
    {    
          // bulletType= Bullet.GetComponent<shoot>().bulletType.ToString();
          switch(bulletType){
            case "Normal":
          
            SpawnBulletType1(); //0.1f
            break;
             case "Aoe":
              
          SpawnBulletType3(); //0.007f
            break;
             case "Vamp":
              
            SpawnBulletType2(); //0.02f
            break;
             default:
            SpawnBulletType1(); // Default behavior
            break;
          }  
        
    }
    private void FixedUpdate() {
           
        if(Input.GetKey(KeyCode.J)){ isShoot=false;
        
        StartCoroutine (ShootRay());}
        
    }
        IEnumerator ShootRay(){ 
            for(int i=0;i<FirePoint.Length;i++){
        RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint[i].position,FirePoint[i].right,Mathf.Infinity,layer);
            if (timer<spawn){timer+=.1f; 
              lineRenderer.enabled=false;
               } //cooldown 3f;
            else{ 
            if(hitInfo){    
              AudioManager.instance.playClip(sound);
                    enemy enemy=hitInfo.transform.GetComponent<enemy>();
                if(enemy!=null){enemy.TakeDamage(rayDamage); 
                } Instantiate(Ray,hitInfo.point,Quaternion.identity); 
                
            lineRenderer.SetPosition(0,FirePoint[i].position);
            lineRenderer.SetPosition(1,hitInfo.point);}
             
            else{ 
              AudioManager.instance.playClip(sound);
                lineRenderer.SetPosition(0,FirePoint[i].position);
                lineRenderer.SetPosition(1,FirePoint[i].position+FirePoint[i].right*100);} 
                lineRenderer.enabled=true; //hien line moi khi ban
                yield return new WaitForSeconds(.02f); //doi 1 frame, ko phai cool down!!
                lineRenderer.enabled=false; //tat line di
                timer=0f;
            } isShoot=true;} }

private void SpawnBulletType3(){ //aoe
    if(isShoot==true){
             if(timer2<spawn2){
                
                timer2 += .05f*(1+atkspd);
                
                }
             else{
         switch (directionState)
    {
        
        case 0:
            SpawnBulletCurv1();
            break;

        case 1:
            SpawnBulletCurv2();
            break;
       case 2:
            SpawnBulletCurv3();
            break;

        // Add more cases as needed
        // ...

        default:
            SpawnBulletCurv3(); // Default behavior
            break;
    }timer2=0f;}
             }
}
private void SpawnBulletCurv1(){
    
    if (timer2 < spawn2)
    {
        timer2 += .002f;
    }
    else
    {
       
  SpawnBulletSingle(FirePoint[0].position, FirePoint[0].rotation);
  bonusSplash=0;
 timer2 = 0f;
        }
       
    }

private void SpawnBulletCurv2(){
    
    if (timer2 < spawn2)
    {
        timer2 += .004f;
    }
    else
    {
        for(int i=3;i<=4;i++){
    SpawnBulletSingle(FirePoint[i].position, FirePoint[i].rotation);
        }
  bonusSplash=1f;
   timer2 = 0f;
        }
       
    }
private void SpawnBulletCurv3(){
    
    if (timer2 < spawn2)
    {
        timer2 += .006f;
    }
    else
    {
       int[] selectedFirepoint={0,3,4};
  foreach(int i in selectedFirepoint){
    
              

           GameObject bullet= objectPool.current.GetPooledObject(Bullet);

           if (bullet != null)
            {
               shoot shoot = bullet.GetComponent<shoot>();

                // Reset the bullet's scale to its original size
                bullet.transform.localScale = shoot.originalScale;

                // Make the bullet from fire point 0 bigger
                if (i == 0)
                {
                    bullet.transform.localScale *= 2f; // Adjust the scale factor as needed
                }

                bullet.transform.position = FirePoint[i].position;
                bullet.transform.rotation = FirePoint[i].rotation;
                bullet.SetActive(true);
            }
        }
 bonusSplash=2f;
  timer2 = 0f;
        }
        
    }

private void SpawnBulletType2(){ //vamp
    if(isShoot==true){
             if(timer2<spawn2){
                
                timer2 += .1f*(1+atkspd);
                
                }
             else{
         switch (directionState)
    {
        
        case 0:
            SpawnBullet45c1();
            break;

        case 1:
            SpawnBullet45c2();
            break;
       case 2:
            SpawnBullet45c3();
            break;

        default:
            SpawnBullet45c3(); // Default behavior
            break;
    }timer2=0f;}
             }
}

      private void SpawnBullet45c1()
{
    float angleStep = 65f / (num - 1); // Spread angle divided by the number of bullets minus 1
    float startingAngle = -7f; // Starting angle for the spread
    float currentAngle = startingAngle;

    if (timer2 < spawn2)
    {
        timer2 += .25f;
    }
    else
    {
        for (int i = 0; i < num-4; i++)
        {
            // Calculate direction for the current bullet
            //Vector3 direction = Quaternion.Euler(0f, 0f, currentAngle) * FirePoint[0].right;
           aoedirection = Quaternion.Euler(0f, 0f, currentAngle) * FirePoint[0].right;
            // Get a bullet from the object pool
            GameObject bullet= objectPool.current.GetPooledObject(Bullet);;

            if (bullet != null)
            {
                bullet.transform.position = FirePoint[0].position;
                bullet.transform.rotation = Quaternion.Euler(0f, 0f, currentAngle) * FirePoint[0].rotation;
                bullet.SetActive(true);

                //bullet.GetComponent<Rigidbody2D>().velocity = direction * 5;
            }

            // Increment the angle for the next bullet
            currentAngle += angleStep;
        }
        timer2 = 0f;
    }
}

 private void SpawnBullet45c2()
{
    float angleStep = 55f / (num - 1); // Spread angle divided by the number of bullets minus 1
    float startingAngle = -55f/4f; // Starting angle for the spread
    float currentAngle = startingAngle;

    if (timer2 < spawn2)
    {
        timer2 += .2f;
    }
    else
    {
        for (int i = 0; i < num-2; i++)
        {
            // Calculate direction for the current bullet
            //Vector3 direction = Quaternion.Euler(0f, 0f, currentAngle) * FirePoint[0].right;
           aoedirection = Quaternion.Euler(0f, 0f, currentAngle) * FirePoint[0].right;
            // Get a bullet from the object pool
            GameObject bullet= objectPool.current.GetPooledObject(Bullet);;

            if (bullet != null)
            {
                bullet.transform.position = FirePoint[0].position;
                bullet.transform.rotation = Quaternion.Euler(0f, 0f, currentAngle) * FirePoint[0].rotation;
                bullet.SetActive(true);

                //bullet.GetComponent<Rigidbody2D>().velocity = direction * 5;
            }

            // Increment the angle for the next bullet
           // startingAngle += angleStep;
             currentAngle += angleStep;
        }
        timer2 = 0f;
    }
}

 private void SpawnBullet45c3()
{
   float angleStep = 65f / (num - 1); // Spread angle divided by the number of bullets minus 1
    float startingAngle = -65f/2; // Starting angle for the spread
    float currentAngle = startingAngle;

    if (timer2 < spawn2)
    {
        timer2 += .1f;
    }
    else
    {
        for (int i = 0; i < num; i++)
        {
            // Calculate direction for the current bullet
            //Vector3 direction = Quaternion.Euler(0f, 0f, currentAngle) * FirePoint[0].right;
           aoedirection = Quaternion.Euler(0f, 0f, currentAngle) * FirePoint[0].right;
            // Get a bullet from the object pool
            GameObject bullet= objectPool.current.GetPooledObject(Bullet);;

            if (bullet != null)
            {
                bullet.transform.position = FirePoint[0].position;
                bullet.transform.rotation = Quaternion.Euler(0f, 0f, currentAngle) * FirePoint[0].rotation;
                bullet.SetActive(true);

                //bullet.GetComponent<Rigidbody2D>().velocity = direction * 5;
            }

            // Increment the angle for the next bullet
            currentAngle += angleStep;
        }
        timer2 = 0f;
    }
}

private void SpawnBulletType1(){
    if(isShoot==true){
             if(timer2<spawn2){
                
                timer2 += .5f*(1+atkspd);
                
                }
             else{
         switch (directionState)
    {
        
        case 0:
            SpawnBullet();
            break;
        case 1:
            SpawnBullet3();
            break;
        case 2:
            SpawnBullet5();
            break;

        // Add more cases as needed
        // ...

        default:
            SpawnBullet5(); // Default behavior
            break;
    }timer2=0f;}
             }
}
        private void SpawnBullet(){ 
            if(timer<spawn){timer += .2f;}
             else{ 
            SpawnBulletSingle(FirePoint[0].position, FirePoint[0].rotation);   
             timer=0f;}

             /*
             if (Time.time > nextFireTime) //FireRate=0.5f;
        {
            nextFireTime = Time.time + FireRate;
            SpawnBulletSingle(FirePoint[0].position, FirePoint[0].rotation);   
        }
             
             */
     } 
     private void SpawnBullet3(){
if(timer<spawn){timer += .2f;}
             else{ 
        for (int i = 0; i < 3; i++)
    {
        SpawnBulletSingle(FirePoint[i].position, FirePoint[i].rotation);
    }  timer=0f;}
     }

     private void SpawnBullet5(){
if(timer<spawn){timer += .2f;}
             else{ 
        foreach (Transform firePoint in FirePoint)
        
    {
        SpawnBulletSingle(firePoint.position, firePoint.rotation);
    } timer=0f;}
     }

private void SpawnBulletSingle(Vector3 position, Quaternion rotation)
{
    GameObject obj = objectPool.current.GetPooledObject(Bullet);
    if (obj == null)
    {
        Debug.LogError("Object pool returned null. Pool might be exhausted or not initialized correctly.");
        return; // Exit the method if no object is available in the pool
    }

    obj.transform.position = position;
    obj.transform.rotation = rotation;
    obj.SetActive(true);
   // Debug.Log("Bullet spawned at position: " + position + " with rotation: " + rotation);
}

 public void ChangeBulletPrefab(GameObject newBulletPrefab) 
 //ChangeBulletPrefab(GameObject newBulletPrefab, int newPoolSize)
    {
        Bullet = newBulletPrefab;
         bulletType= Bullet.GetComponent<shoot>().bulletType.ToString();
          Debug.Log("da thay loai dan "+bulletType);
      switch(bulletType){
            case "Normal":
             Poolnum=120;
            SpawnBulletType1();
            break;
             case "Aoe":
              Poolnum=20;
          SpawnBulletType3();
            break;
             case "Vamp":
               Poolnum=50;
            SpawnBulletType2();
            break;}
            Debug.Log("da thay pool size "+Poolnum);
        objectPool.current.InitializePool(Bullet,Poolnum);
    }

       
    public void addRange()
{
    directionState++;
   // directionState2=directionState % 3;

    // Choose the appropriate method based on the current directionState

}
        }






