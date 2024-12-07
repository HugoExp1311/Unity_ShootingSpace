using System.Collections;
using System.Collections.Generic;
using ES3Types;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelTransition : MonoBehaviour
{ 
 [SerializeField] private  GameObject player;
   [SerializeField] private GameObject manageScript; 
    public bool isLoaded=false; public static LevelTransition instance; bool onMenuPause,onMenuOver =true;
// co the dung public gameObject player sau do o duoi player.getcomponent<healthmain>
  
    private void Awake()
    { 
 if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        } 
//Singleton

   SaveLoadManager();
    }
    void SaveLoadManager(){
      if( SceneManager.GetActiveScene().buildIndex==0 ){
        Savethis(); 
        }
    else if(SceneManager.GetActiveScene().buildIndex==1){
      
   /*   if(onMenuOver==ES3.Load<bool>("onMenuPause")|| onMenuPause==ES3.Load<bool>("onMenuOver")){
Loadthis();
      } 
      else{
        //Savethis();
        return;
        } */
        Savethis();
    }
    else{
      
        if (!ES3.FileExists()){ // neu chua co save file thi ko load
            return;}
             Loadthis(); //moi bat dau vo scene moi se load data
             }
    }
   void FindPlayerData(){
    player=GameObject.FindWithTag("Player");
  //manageScript=GameObject.Find("E3SimpleManager");
  manageScript=GameObject.FindWithTag("Data");
  if(manageScript!=null){
    Debug.Log("cant find simpleManager");
  }
  if(player!=null){
    Debug.Log("cant find player");
  }
   }
   private void Start() {
    FindPlayerData();
   }

   void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    FindPlayerData();
    SaveLoadManager();
   //manageScript= GameObject.Find("E3SimpleManager");
   }

          public void TransitionToNextLevel() // goi ham -> save lai data scene cu-> loadscene tiep theo 
    {
         
        Savethis();

        //load next scene
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
       
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            isLoaded=true;
            SceneManager.LoadSceneAsync(nextSceneIndex);
            //Loadthis();
            isLoaded=false;
            
        }
        else
        {
            Debug.LogWarning("No more levels to transition to.");
        }
        
    }
        
       
        
    
    
    public void Loadthis(){ //Load the data to the origin player 
        
         player.GetComponent<fireBullet>().directionState=ES3.Load<int>("directionState");
        player.GetComponent<healthMain>().health=ES3.Load<float>("currentHP");
        player.GetComponent<healthMain>().healthMax=ES3.Load<float>("maxHP"); 
       player.GetComponent<healthMain>().currentLevel=ES3.Load<float>("currentLevel");
       player.GetComponent<healthMain>().currentExp=ES3.Load<float>("currentExp");
       player.GetComponent<healthMain>().maxExp=ES3.Load<float>("maxExp");
       player.GetComponent<fireBullet>().bonusDamage=ES3.Load<int>("damage");
       player.GetComponent<fireBullet>().bonusSpeed=ES3.Load<float>("bonusSpeed");
       player.GetComponent<fireBullet>().atkspd=ES3.Load<float>("atkspd");
      
       player.GetComponent<fireBullet>().ChangeBulletPrefab(ES3.Load<GameObject>("bulletType"));
      // player.GetComponent<fireBullet>().Bullet=ES3.Load<GameObject>("bulletType");
      player.GetComponent<inventory>().coinCount=ES3.Load<int>("coinCount");

    }
     public void Savethis(){ //Get the data from the simple manager
        simpleManager simpleManager= manageScript.GetComponent<simpleManager>();
       //simpleManager.GetComponent<simpleManager>();
        ES3.Save("directionState",simpleManager.directionState);
        ES3.Save("currentHP",simpleManager.currentHP);
        ES3.Save("maxHP",simpleManager.maxHP);
        ES3.Save("maxExp",simpleManager.maxExp);
        ES3.Save("currentExp",simpleManager.currentExp);
        ES3.Save("currentLevel",simpleManager.currentLevel);
        ES3.Save("damage",simpleManager.bonusDamage);
        ES3.Save("bonusSpeed",simpleManager.bonusSpeed);
        ES3.Save("atkspd",simpleManager.atkspd);
        ES3.Save("bulletType",simpleManager.bulletType); 
        ES3.Save("coinCount",simpleManager.coinCount);
        
    }

    
   private void OnEnable() {
    
    BossHandle.BossDied+=TransitionToNextLevel;
     SceneManager.sceneLoaded += OnSceneLoaded;
    
   }
   private void OnDisable() {
    SceneManager.sceneLoaded -= OnSceneLoaded;
    BossHandle.BossDied-=TransitionToNextLevel;
    
   }
    public void TransitionToCurrentLevel() // goi ham -> save lai data scene cu-> loadscene mainmenu
    {
        Savethis();
        SceneManager.LoadSceneAsync(ES3.Load<int>("sceneIndex"));
            //Loadthis();
            
            
        }
    public void play(){
   // datapersistence.NewGame();
      

//ES3.DeleteFile("SaveFile.es3");


    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
   
}
   public void settingMenu(){
    SceneManager.LoadSceneAsync("SettingMenu");
}
public void mainMenu(){
    SceneManager.LoadSceneAsync("MainMenu");
}
    public void quit(){
        Application.Quit();
    }
    }

   

