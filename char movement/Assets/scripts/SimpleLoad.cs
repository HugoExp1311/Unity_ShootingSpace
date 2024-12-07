using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLoad : MonoBehaviour
{public GameObject manageScript;
    public void Loadthis(){
        simpleManager simpleManager= manageScript.GetComponent<simpleManager>();
        simpleManager.directionState=ES3.Load<int>("directionState");
        simpleManager.currentHP=ES3.Load<float>("currentHP");
        simpleManager.maxHP=ES3.Load<float>("maxHP"); 

    }
}
