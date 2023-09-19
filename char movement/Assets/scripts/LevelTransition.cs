using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelTransition : MonoBehaviour
{
          public void TransitionToNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more levels to transition to.");
        }
    }
   private void OnEnable() {
    BossHandle.BossDied+=TransitionToNextLevel;
   }
   private void OnDisable() {
    BossHandle.BossDied-=TransitionToNextLevel;
   }
    }

   

