using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
   public GameObject pauseMenu; 
   private CanvasManager canvasManager; movement characterMovement; onDIalogEnd ondialogEnd; 
   public bool isPause; LevelTransition levelTransition; public bool onMenu=false;
  HideMouse HideMouse; private static PauseMenu instance; 
 
  /*private void Awake() {
     if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
  }*/
   private void Start() {
    pauseMenu.SetActive(false);
    canvasManager=FindObjectOfType<CanvasManager>();
  characterMovement = FindObjectOfType<movement>(); 
  levelTransition = FindObjectOfType<LevelTransition>();
   }
   private void Update() {
    if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) && !canvasManager.isConversation){
       
       if(isPause ){
      
        ResumeGame();
       } else{
      
        canvasManager.ShowPauseCanvas();
        PauseGame();}
       
    
    }}
   
public void PauseGame(){
   SavePos();
    Cursor.visible=true;
        pauseMenu.SetActive(true);
        SetCharacterMovementEnabled(false);
        Time.timeScale=0f;
        isPause=true;
}
public void ResumeGame(){
    //HideMouse hideMouse= FindObjectOfType<HideMouse>();
    //hideMouse.ToggleCursorVisibility();
    Cursor.visible=false;
  SetCharacterMovementEnabled(true);
  // characterMovement.lockMouseToSavedPosition=true;
    
        pauseMenu.SetActive(false);
       //SetCharacterMovementEnabled(true);
       
        Time.timeScale=1f;
        isPause=false;
}
public void RetryGame(){
     Time.timeScale=1f;
   SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
}
public void BacktoMainMenu(){
     Time.timeScale=1f;
    Cursor.visible=true;
    LevelTransition.instance.Savethis();
     int SceneIndex = SceneManager.GetActiveScene().buildIndex;
    ES3.Save("sceneIndex",SceneIndex); //save  int SceneIndex into the key sceneIndex
    onMenu = true;
    ES3.Save("onMenuPause",onMenu);
    onMenu =false;
    SceneManager.LoadSceneAsync("MainMenu");
    
    
}
public void QuitGame(){
    LevelTransition.instance.Savethis();
     Time.timeScale=1f;
    Application.Quit();
}
public void SetCharacterMovementEnabled(bool enabled)
{
   
    
    if (characterMovement != null)
    {
        characterMovement.isAttachToMouse = enabled;
       
        
    }
}
void SavePos(){
     ES3.Save("savePos",characterMovement.transform.position);
    
}

IEnumerator ResumeDelay (){
   characterMovement.transform.position=ES3.Load<Vector3>("savePos");
  
           
    yield return new WaitForSeconds(.5f);
        characterMovement.isAttachToMouse=enabled;

}

}
