using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random; //math vs random

public class BigQuyen : MonoBehaviour,IEnemy
{
  [Header("Fire Projectile")]
     public Transform FirePoint;
     
    public GameObject[] SubLaser;
    public GameObject[] SubLaser2;
    public float shieldStack=10; public bool isShoot2=true;
    
     [SerializeField] private int num;
    public EnemyClass enemyClass;

public GameObject Bullet;
    
float timer=0f;  float spawn=2f;
float timer2=0f; float spawn2=1f;


public float raycd =3f;


 [Header("EXP, event, sound")]
 public AudioClip angryQuyen;
    public AudioClip rayP2sound;
    public AudioClip raywarningSound;
    [SerializeField] private int expAmount;
public static event Action Ondeath;
public BossHandle bossHandle;
  //public GameObject spawnerPrefab;

  [Header("Health and Coin")]
   [SerializeField] private float healthMax;
   [SerializeField] private float health;
   //public float BarHealthCurrent=>health;
   //public float BarHealthMax=>healthMax;
   [SerializeField] HP_Enemy1 hPbar;
    public GameObject Coin;
    //public GameObject shieldbreak;
    

    [Header("Movement")]
   
    float maxdis=12f;
  
    private void Awake() {
      
      hPbar=GetComponentInChildren<HP_Enemy1>();
       
    }

        private void Start() {
         num = enemyClass.firePoints;

  healthMax=enemyClass.health;
  health=healthMax;
  hPbar.UpdateHealthBar(health,healthMax);
//StartCoroutine(WaitingRay());

}
IEnumerator WaitingRay(){
  
   AudioManager.instance.WaitAndPlaySound(raywarningSound,raycd);
   foreach(GameObject sublaser in SubLaser){  
      
   sublaser.GetComponentInChildren<test>().LaserPhase1(); }   
  yield return new WaitForSeconds(raycd);
}
   
    private void Update() {
        
          
      if(timer<spawn){timer += .05f;
       
      }
             else{
         
              
              SpawnBullet(); 
              
             timer=0f;}
    }

 

   public  void TakeDamage(float damage){
  health-=damage;
  if(health%3==1 && health>=(healthMax*0.65f)){
     StartCoroutine(WaitingRay());
     }
  hPbar.UpdateHealthBar(health,healthMax);
  if (health<=(healthMax*0.5f) && isShoot2){ 
    
      AudioManager.instance.playClip(rayP2sound);
  foreach(GameObject sublaser in SubLaser2){  
      
   sublaser.GetComponentInChildren<test>().LaserPhase2(); 
 
    
 //active sub mini boss laser gameobject and shield stack
  } isShoot2=false;
  
            }

    if (health<=0f){ 
      AudioManager.instance.playClip(angryQuyen);
      health=0f;
    if (health==0f){
      bossHandle.Died();
            //spawnerPrefab.SetActive(false);
       // OnDeath?.Invoke();
      ExpManager.instance.AddExp(expAmount);
      Instantiate(Coin,transform.position,Quaternion.identity);}
        Destroy(gameObject);
        }}
        private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.TryGetComponent<healthMain>(out healthMain healthMain)){
            healthMain.TakeDamage(500);
        }}  

 
     private void SpawnBullet(){
      float angleStep=45f / num-1; //45 canh quat, 360 hinh tron
      float angle=-45f/2f; //starting angle
      //float angle2=-45f/1f;

    if(timer2<spawn2){timer2+=.5f;}
        else{
            for(int i=0;i<num;i++){
              
             Vector3 direction = Quaternion.Euler(0f, 0f, angle + i * angleStep) * new Vector3(0,-1,0);
            Bullet= projectilePool.current.GetPool(); //make ref 
            //if(Bullet==null) {yield return 0;}
            Bullet.transform.position=FirePoint.position;
            Bullet.transform.rotation=FirePoint.rotation;
            Bullet.SetActive(true);

            Bullet.GetComponent<Rigidbody2D>().velocity=direction*5;
            angle+=angleStep;
            
            
            
        }timer2=0f;
        }}

private void ShuffleArray<T>(T[] array)
{
    int n = array.Length;
    for (int i = n - 1; i > 0; i--)
    {
        // Use Time.time as the seed
        float randomTime = Time.time * 1000f; // Multiply by 1000 to get more precision
        Random.InitState((int)(randomTime % int.MaxValue));

        int j = Random.Range(0, i + 1);
        T temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}

 
}
