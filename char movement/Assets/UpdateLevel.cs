using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateLevel : MonoBehaviour
{
   
    // Singleton pattern to ensure there's only one instance.
    public static UpdateLevel Instance;

    // The score variable.
    private int playerScore;

    private void Awake()
    {
        // Singleton pattern.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Property to access and update the score.
    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }
}


