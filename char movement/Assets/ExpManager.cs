using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpManager : MonoBehaviour
{ public static ExpManager instance;
    public delegate void ExpChange(int expAmount);
    public event ExpChange OnExpChange;
    //singleton on awake
    private void Awake(){
        if (instance ==null) { 
        instance=this;
       } 
       else if(instance!=this){ 
        Destroy(gameObject);
       } DontDestroyOnLoad(this);
       /*
       cach 2?:
       if(instance!=null && instance!=this){
        Destroy(this);
       } else{
        instance=this;
       }

        */
    }
    public void AddExp(int expAmount){
        OnExpChange?.Invoke(expAmount);  // if OnExpChange != null -> invoke
    }
}
