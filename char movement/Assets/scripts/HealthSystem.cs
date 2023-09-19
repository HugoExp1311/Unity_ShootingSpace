using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HealthSystem {
    public event EventHandler HealthChanged;
    private int health; private int healthMax;
    public HealthSystem (int healthMax){
        this.healthMax=healthMax;
        health=healthMax;
    }
    public int GetHealth(){
        return health;
    }
    public float GetHealthPercentage(){
        return (float) health/healthMax;
    }
    
    public int Damage(int damageAmount){
        health-=damageAmount;
        if(health<0){health=0;}
        if(HealthChanged!=null){HealthChanged(this,EventArgs.Empty);}
        return health;
    }
    public int Heal(int healAmount){
        health+=healAmount;
        if(health>healthMax){health=healthMax;}
         if(HealthChanged!=null){HealthChanged(this,EventArgs.Empty);}
        return health;
    }
}

