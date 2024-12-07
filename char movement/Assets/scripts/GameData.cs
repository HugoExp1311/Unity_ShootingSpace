using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long lastUpdated;
    public healthMain healthmain;
    public float health;
    public float maxhealth;
    public fireBullet firebullet;
    public int directionState;
    

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData() 
    {
       // this.health=healthmain.health;
       //  this.maxhealth=healthmain.healthMax;
       // this.directionState=firebullet.directionState;
        
    }
}