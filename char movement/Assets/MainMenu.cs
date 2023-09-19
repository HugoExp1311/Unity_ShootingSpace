using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{   public void play(){
    
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   
}
public void settingMenu(){
    SceneManager.LoadScene("SettingMenu");
}
public void mainMenu(){
    SceneManager.LoadScene("MainMenu");
}
    public void quit(){
        Application.Quit();
    }
}