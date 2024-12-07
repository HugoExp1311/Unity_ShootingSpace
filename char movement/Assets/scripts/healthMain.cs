using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

public class healthMain : MonoBehaviour
{   //public fireBullet fireBullet;
//public EnemyClass enemyClass;
public LevelTransition levelTransition;
    public float health; public float totalHealthLost = 0f; 

 
  public float healthMax;
    public static event Action OnDeath; //event when player die
    public GameObject Explo; public GameObject spaceship; public GameObject shieldbreak;
    public AudioClip exploSound,hurtSound; //audio clip explosion 
     public UnityEvent levelup; // New event for level up
     public UnityEvent shieldup, shielddown;
    public float maxExp, currentExp,currentLevel, skillPoint, shieldStack;
    private CanvasManager canvasManager;
 
 private void Awake() {
    canvasManager=FindObjectOfType<CanvasManager>();
       if(SceneManager.GetActiveScene().buildIndex==1){

    maxExp=2; currentLevel=1;
    healthMax=300f;  
  //  healthMax=enemyClass.health; game vampiresurvival
   // healthMax = 3;
   health=healthMax;
}
 }
private void Start() {
        
 //   healthMax=enemyClass.health;
 //  healthMax = 300;
  // health=healthMax;
//   Debug.Log("slime hpmax: "+ healthMax);
   //    Debug.Log("slime hp: "+ health);

  /* if(levelTransition.isLoaded){
    health=ES3.Load<float>("currentHP", health);
healthMax=ES3.Load<float>("maxHP", healthMax);
fireBullet.directionState=ES3.Load<int>("directionState",fireBullet
.directionState);}*/


    /*template de thay doi script 1 trong gameobject 1 bang script 2 trong gameobject2

    GameObject thisobjectPool= GameObject.FindWithTag("Pool");
    if(thisobjectPool!=null){
       objectPool objectPoolref=thisobjectPool.GetComponent<objectPool>();
    }*/
}

//save and load
    public  void TakeDamage(float damage){
        if(shieldStack!=0 && shieldStack>0){
        MinusShield(); }
       
       //Instantiate(shieldbreak,transform.position,quaternion.identity);
        if(shieldStack==0){ 
    health-=damage;
    totalHealthLost+=damage;
    AudioManager.instance.playClip(hurtSound);
    }
        if (health<=0f){Instantiate(Explo,transform.position,Quaternion.identity);
    AudioManager.instance.playClip(exploSound);
    spaceship.SetActive(false);
    canvasManager.ShowGameOverCanvas();
    OnDeath?.Invoke();}
    }
    public void Heal(float healAmount){
        health+=healAmount;
        if(health>healthMax){health=healthMax;}
    }
    public void AddShield(int shieldAmount){
        shieldStack+=shieldAmount;
        shieldup.Invoke();
    }
    public void MinusShield(){
        shieldStack--;
       shielddown.Invoke();
    }
   
    public void HoldExpChange(int newExp){
        
        currentExp+=newExp;
        if(currentExp>=maxExp){     //Level Up

           LevelUp();
       
        }
    }

    public void LevelUp(){
            currentLevel++;
            levelup.Invoke(); //update level up UI, etc invoke increment level, choose skill manager
            skillPoint+=3; 
  
            currentExp=0; 
            maxExp+=(5*currentLevel); 
      
       
    }
     private void OnEnable() {
        ExpManager.instance.OnExpChange+=HoldExpChange; 
        
    }
    private void OnDisable() {
        ExpManager.instance.OnExpChange-=HoldExpChange;
    }  
}

   