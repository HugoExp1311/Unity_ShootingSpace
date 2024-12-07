using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingbacktomenu : MonoBehaviour
{
   public void mainMenu(){
    SceneManager.LoadScene(0);
}
    public void quit(){
        Application.Quit();
    }
}
