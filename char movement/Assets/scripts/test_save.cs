using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class test_save : MonoBehaviour
{
  LevelTransition levelTransition;
   /* public int number=2;
    public int loadnumber=0;
    public void incrementnum(){
        number++;
        ES3.Save("myInt", number);


    }
    public void shownumUI(){
        loadnumber=ES3.Load<int>("myInt");
        GetComponent<TextMeshProUGUI>().text= $"{loadnumber}"; //mix string text with int variables

    }*/
private void Start() {
    levelTransition=FindObjectOfType<LevelTransition>();}
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.L)){
levelTransition.TransitionToNextLevel();
        }
    }
}
