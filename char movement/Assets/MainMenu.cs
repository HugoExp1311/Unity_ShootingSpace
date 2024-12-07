using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{   LevelTransition levelTransition; bool isClickNewGame;
    
//public DataPersistenceManager datapersistence;
    public void play(){
   // datapersistence.NewGame();
      

ES3.DeleteFile("SaveFile.es3");
//isClickNewGame=true;
//ES3.Save("isClickNewGame",isClickNewGame);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   
}

public void continuegame(){
   levelTransition=FindObjectOfType<LevelTransition>();
   levelTransition.Savethis();
       SceneManager.LoadScene(ES3.Load<int>("sceneIndex")); //load the key of sceneIndex from the pauseMenu


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