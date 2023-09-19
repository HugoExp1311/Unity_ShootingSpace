using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class healthMain : MonoBehaviour
{   public float healthMax;
    public float health;
    public static event Action OnDeath; 
    public GameObject Explo; public GameObject spaceship;
    public AudioClip sound;
    [SerializeField] int maxExp=2, currentExp,currentLevel, skillPoint; 
    
private void Start() {
    healthMax=100f;  //healthMax=playerClass.health;
    health=healthMax;
}
    public  void TakeDamage(float damage){
    health-=damage;
        if (health<=0f){Instantiate(Explo,transform.position,Quaternion.identity);
    AudioManager.instance.playClip(sound);
    spaceship.SetActive(false);
    OnDeath?.Invoke();}
    }
    public void Heal(float healAmount){
        health+=healAmount;
        if(health>healthMax){health=healthMax;}
    }
    private void HoldExpChange(int newExp){
        currentExp+=newExp;
        if(currentExp>=maxExp){
            skillPoint+=3; currentLevel++;
            currentExp=0; maxExp+=(5*currentLevel);
        }}
     private void OnEnable() {
        ExpManager.instance.OnExpChange+=HoldExpChange;
        
    }
    private void OnDisable() {
        ExpManager.instance.OnExpChange-=HoldExpChange;
    }
     
}
   