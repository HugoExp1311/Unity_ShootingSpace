using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ExpManager : MonoBehaviour
{ public static ExpManager instance; //can use anywhere in your game
    public delegate void ExpChange(int expAmount); //khoi tao delegate void ten la ExpChange
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
