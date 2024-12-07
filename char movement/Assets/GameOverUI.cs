using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverUI : MonoBehaviour
{ public GameObject gameOverMenu;  private CanvasManager canvasManager;
 private static GameOverUI instance; public bool onMenu=false;

private void Awake() {
    canvasManager=FindObjectOfType<CanvasManager>();
}
   private void OnEnable() {
    healthMain.OnDeath+=EnableGameOverMenu;
   }
   private void OnDisable() {
    healthMain.OnDeath-=EnableGameOverMenu;
   }
   public void EnableGameOverMenu(){
    
    gameOverMenu.SetActive(true);
    Time.timeScale=0;
    Cursor.visible=true;

   }
   public void RestartLevel(){
    Time.timeScale=1;
    canvasManager.ResetGameState();
    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);  //load current scene where you die
    

   }
   public void mainMenu(){
     Time.timeScale=1;
    canvasManager.ResetGameState();
   onMenu = true;
    ES3.Save("onMenuOver",onMenu);
    onMenu=false;
    SceneManager.LoadScene("MainMenu");
}
}
