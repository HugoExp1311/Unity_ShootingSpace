using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using Platformer.Mechanics;

public class SaveManager : MonoBehaviour
{
    public Transform player;
    public Button loadButton;
    public Transform[] enemies;
    public GameObject[] tokens;

    // This is called when the scene first loads.
    void Awake()
    {
        // Assign all of the variables we need.
        // You could manually assign the variables in the inspector instead if this looks complex.
        player = GameObject.Find("Player").transform;
        loadButton = FindObjectsOfType<Button>(true).First(btn => btn.name == "Load Button");
        // Note: we sort the enemies and tokens by their sibling index to ensure they're always in the same order.
        //enemies = FindObjectsOfType<EnemyController>().Select(obj => obj.transform).OrderBy(obj => obj.transform.GetSiblingIndex()).ToArray();
        //tokens = FindObjectsOfType<TokenInstance>().Select(obj => obj.gameObject).OrderBy(obj => obj.transform.GetSiblingIndex()).ToArray();

        // If no save data exists, don't load anything.
        if (!ES3.FileExists())
            return;

        // Make the load button interactable now we know there is save data.
        loadButton.interactable = true;

        // Load the position of the player. 
        player.position = ES3.Load<Vector3>("playerPosition");

        // Load the List of Enemy Transforms. These will be loaded by reference.
        ES3.Load<Transform[]>("enemies");

        // Load the List of Token active states and assign them back to their corresponding Tokens.
        var tokensActive = ES3.Load<bool[]>("tokensActive");
        for (int i = 0; i < tokensActive.Length; i++)
            tokens[i].SetActive(tokensActive[i]);
    }

    // This is triggered by the Load button in the main menu (press Esc to open it).
    public void Load()
    {
        // Reload the scene.
        // This will revert everything and then call the Awake() method above, loading our data into a fresh scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    // This is triggered by the Save button in the main menu (press Esc to open it).
    public void Save()
    {
        // Get the position of the Player GameObject and save it to a key named "playerPosition".
        ES3.Save("playerPosition", player.position);

        // Save the Transforms of the Enemies to save their positions.
        ES3.Save("enemies", enemies);

        // Put the active states into an array and save them to a key named "tokensActive".
        ES3.Save("tokensActive", tokens.Select(token => token.activeSelf).ToArray());

        // Make the load button interactable.
        loadButton.interactable = true;
    }
}