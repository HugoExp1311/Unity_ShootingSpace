using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
   public GameObject pauseMenu;
   public bool isPause;
  HideMouse HideMouse;
   private void Start() {
    pauseMenu.SetActive(false);
    
   }
   private void Update() {
    if(Input.GetKeyDown(KeyCode.Escape)){
       if(isPause){
        ResumeGame();
       } else{PauseGame();}
    }}
public void PauseGame(){
    Cursor.visible=true;
        pauseMenu.SetActive(true);
        SetCharacterMovementEnabled(false);
        Time.timeScale=0f;
        isPause=true;
}
public void ResumeGame(){
    //HideMouse hideMouse= FindObjectOfType<HideMouse>();
    //hideMouse.ToggleCursorVisibility();
    Cursor.visible=true;
        pauseMenu.SetActive(false);
        SetCharacterMovementEnabled(true);
        
        Time.timeScale=1f;
        isPause=false;
}
public void BacktoMainMenu(){
    Cursor.visible=true;
    Time.timeScale=1f;
    SceneManager.LoadScene("MainMenu");
    
    
}
public void QuitGame(){
    Application.Quit();
}
public void SetCharacterMovementEnabled(bool enabled)
{
    movement characterMovement = FindObjectOfType<movement>();
    
    if (characterMovement != null)
    {
        characterMovement.isAttachToMouse = enabled;
        
    }
}

}
