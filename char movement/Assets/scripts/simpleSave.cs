using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleSave : MonoBehaviour
{
    public GameObject manageScript;
    public void Savethis(){
        simpleManager simpleManager= manageScript.GetComponent<simpleManager>();
        ES3.Save("directionState",simpleManager.directionState);
        ES3.Save("currentHP",simpleManager.currentHP);
        ES3.Save("maxHP",simpleManager.maxHP);

    }
}
