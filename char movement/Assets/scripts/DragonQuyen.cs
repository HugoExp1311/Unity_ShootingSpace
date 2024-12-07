using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics; //math vs random
using UnityEngine;
using Random = UnityEngine.Random; //math vs random

public class DragonQuyen : MonoBehaviour,IEnemy
{
  [Header("Fire Projectile")]
     public Transform FirePoint;
     
    public GameObject[] SubSquare;
    [SerializeField] private bool isSpawnDmgArea=true;
    
     [SerializeField] private int num;
    public EnemyClass enemyClass;

public GameObject Bullet;

    
float timer=0f;  float spawn=2f;
float timer2=0f; float spawn2=1f;

public bool isShoot=true;   //private HashSet<int> previousActiveIndices = new HashSet<int>();

 [Header("EXP, event, sound")]
     public AudioClip angryQuyen1, angryQuyen2;
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
    Transform target; Vector2 MoveDirection; Rigidbody2D rb;    
     public Vector3 randDir; 

    [SerializeField] private float moveSpeed=5f,dashSpeed=10f,dashDuration=1f,DashCooldown=2f;
  
    private void Awake() {
      rb=GetComponent<Rigidbody2D>();
      hPbar=GetComponentInChildren<HP_Enemy1>();
       
    }
    private void Update() {
      if(timer<spawn){timer += .1f;}
             else{SpawnBullet();
             timer=0f;}
    }
    private void Start() {
         num = enemyClass.firePoints;

  healthMax=enemyClass.health;
  health=healthMax;
  hPbar.UpdateHealthBar(health,healthMax);
  target=GameObject.FindWithTag("Player").transform;
  randDir=new Vector3(Random.Range(-5,5),Random.Range(-5,5));

}
 

   public  void TakeDamage(float damage){
  health-=damage;
  hPbar.UpdateHealthBar(health,healthMax);
  if (health<=(healthMax/1.5f)){ 
    AudioManager.instance.playClip(angryQuyen1);
    if(isSpawnDmgArea==true){
       StartCoroutine(SpawnDmgArea()); isSpawnDmgArea=false;} //phase 2
        
            }

    if (health<=0f){ health=0f;
     AudioManager.instance.playClip(angryQuyen2);
    if (health==0f){
      bossHandle.Died();
            //spawnerPrefab.SetActive(false);
       // OnDeath?.Invoke();
      ExpManager.instance.AddExp(expAmount);
      Instantiate(Coin,transform.position+randDir,Quaternion.identity);}
        Destroy(gameObject);
        }}
        private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.TryGetComponent<healthMain>(out healthMain healthMain)){
            healthMain.TakeDamage(500);
        }}  

 
     private void SpawnBullet(){
      float angleStep=360f / num-1; //45 canh quat, 360 hinh tron
      float angle=-45f/Random.Range(1f,2f); //starting angle
      //float angle2=-45f/1f;

    if(timer2<spawn2){timer2+=.25f;}
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

       IEnumerator SpawnDmgArea(){
       /* foreach(GameObject sub in SubSquare){
          Debug.Log("WARNING !!!!!");
      yield return new WaitForSeconds(3f);
        sub.SetActive(true);
                yield return new WaitForSeconds(3f);

sub.SetActive(false);

        yield return new WaitForSeconds(3f);}*/
        ShuffleArray(SubSquare);
      //  for(int i=0;i<10;i++){ //lap 5 lan
while(health>=100){
          ShuffleArray(SubSquare); //shuffle 5 lan
        //foreach(GameObject subsquare in SubSquare){ 
       // for(int j=0;j<SubSquare.Length;j++){ //in 3 cai dau trong 4 cai xong roi shuffle
          SubSquare[0].SetActive(true);
          SubSquare[1].SetActive(true);
          SubSquare[2].SetActive(true);
          

          
                yield return new WaitForSeconds(3f);
          SubSquare[0].SetActive(false);
          SubSquare[1].SetActive(false);
          SubSquare[2].SetActive(false);
          
       yield return new WaitForSeconds(1.5f);

        //}
        }
       }

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
