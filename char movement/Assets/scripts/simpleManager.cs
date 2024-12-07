using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class simpleManager : MonoBehaviour
{
   GameObject player;

    //public healthMain healthMain;
    //public fireBullet fireBullet;
    [Header("healthMain")]
 public float currentHP;
public float maxHP; public float totalHealthLost;
 public float maxExp; public int coinCount;
 public float currentExp;
 public float currentLevel;

[Header("fireBullet")]
public int directionState; public GameObject bulletType;
   
  public float bonusSpeed; public int bonusDamage; public float atkspd; public static simpleManager instance;
   
    private void Awake()
    { 
 if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } }
   private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            var fireBullet = player.GetComponent<fireBullet>();
            var healthMain = player.GetComponent<healthMain>();
            var Inventory = player.GetComponent<inventory>();
            

            if (fireBullet != null)
            {
                directionState = fireBullet.directionState;
                bonusDamage=fireBullet.bonusDamage;
                bonusSpeed=fireBullet.bonusSpeed;
               atkspd=fireBullet.atkspd;
               bulletType=fireBullet.Bullet;
            }

            if (healthMain != null)
            {
                currentHP = healthMain.health;
                maxHP = healthMain.healthMax;
                totalHealthLost = healthMain.totalHealthLost;
                maxExp = healthMain.maxExp;
                currentExp = healthMain.currentExp;
                currentLevel = healthMain.currentLevel;
            }
            if(Inventory!=null){
              coinCount=Inventory.coinCount;
            }
        }
      /*  else
        {
            // Handle the case when the player is null (e.g., reset stats or do nothing)
            currentHP = 0;
            maxHP = 0;
            maxExp = 0;
            currentExp = 0;
            currentLevel = 0;
            bonusDamage=0;
            bonusSpeed=0;
            atkspd=0;
        } */
    }
    /* private void Update() { //null ref exeception error
      player=GameObject.FindGameObjectWithTag("Player");
      
        directionState=player.GetComponent<fireBullet>().directionState;
        currentHP=player.GetComponent<healthMain>().health;
        maxHP=player.GetComponent<healthMain>().healthMax;
         maxExp=player.GetComponent<healthMain>().maxExp;
          currentExp=player.GetComponent<healthMain>().currentExp;
        
        currentLevel=player.GetComponent<healthMain>().currentLevel;
        damage= player.GetComponent<fireBullet>().Bullet.GetComponent<shoot>().damage;
currentdamage=damage+player.GetComponent<fireBullet>().Bullet.GetComponent<shoot>().baseDamage;
        
    }
  */




}
