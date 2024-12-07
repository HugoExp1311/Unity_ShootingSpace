using UnityEngine;
 using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject pauseCanvas;
     [SerializeField] private GameObject skillChoiceCanvas;

    private bool isGameOver;
    private bool isPaused;
    private bool isChoosingSkill;
    public bool isConversation;
    public static CanvasManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
             FindCanvases();
            

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
       // gameOverCanvas.SetActive(false);
      
        isGameOver = false;
        isPaused = false;
        isChoosingSkill=false;
        
        FindCanvases();
    }
   void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reassign the canvas references when a new scene is loaded
        FindCanvases();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
     
    private void FindCanvases()
    {
        gameOverCanvas = GameObject.Find("GameOverCanvas");
        pauseCanvas = GameObject.Find("PauseCanvas");
        skillChoiceCanvas=GameObject.Find("SkillChoiceCanvas");

        if (gameOverCanvas == null)
        {
            Debug.LogError("GameOverCanvas not found in the scene!");
        }
        
        if (pauseCanvas == null)
        {
            Debug.LogError("PauseCanvas not found in the scene!");
        }
    }


    // Call this method when the player dies
    public void ShowGameOverCanvas()
    {
        if (!isGameOver && !isConversation)
        {
                        Debug.Log("Show GAME over Canvas");

            gameOverCanvas.SetActive(true);
            pauseCanvas.SetActive(false); // Ensure pause canvas is turned off
            isGameOver = true;
           
        }
    }
       public void ShowSKillChoiceCanvas()
    {
        if (!isChoosingSkill)
        {
                        Debug.Log("Show Skill Choice Canvas");

           skillChoiceCanvas.SetActive(true);
            pauseCanvas.SetActive(false); // Ensure pause canvas is turned off
            isChoosingSkill = true;
        }
    }

    // Call this method when the pause button is pressed
    public void ShowPauseCanvas()
    {
        if (!isPaused) // Prevent showing pause if game over is active
        {
            Debug.Log("Show Pause Canvas");
            pauseCanvas.SetActive(true);
            // Optionally, you can add any additional logic to pause the game
            isPaused = true;
        }
    }
    public void turnOnPauseCanvas(){
       
        pauseCanvas.SetActive(true);
    }

    // Call this method when the resume button is pressed in the pause menu
    public void HidePauseCanvas()
    {
        if (isPaused)
        {
                        Debug.Log("hide Pause Canvas");

            pauseCanvas.SetActive(false);
            // Optionally, you can add any additional logic to resume the game
            isPaused = false;
        }
    }

    // Optionally, call this method to reset the game state when restarting the game
    public void ResetGameState()
    {
    
        isGameOver = false;
        isPaused = false;
         isChoosingSkill=false;
         
    }
}
