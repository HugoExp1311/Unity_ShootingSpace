using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverUI : MonoBehaviour
{ public GameObject gameOverMenu;

   private void OnEnable() {
    healthMain.OnDeath+=EnableGameOverMenu;
   }
   private void OnDisable() {
    healthMain.OnDeath-=EnableGameOverMenu;
   }
   public void EnableGameOverMenu(){
    gameOverMenu.SetActive(true);
    Cursor.visible=true;
   }
   public void RestartLevel(){
    
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  //load current scene where you die
    

   }
   public void mainMenu(){
    
    SceneManager.LoadScene("MainMenu");
}
}
