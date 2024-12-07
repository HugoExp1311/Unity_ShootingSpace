using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SaveSystem : MonoBehaviour
{
    public string playerHealthKey = "PlayerHealth", directionStateKey="DirectionState",
    
    sceneKey = "SceneIndex", savePresentKey = "SavePresent";
    public LoadedData LoadedData { get; private set; }

    public UnityEvent<bool> OnDataLoadedResult;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        var result = LoadData();
        OnDataLoadedResult?.Invoke(result);
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteKey(playerHealthKey);
        PlayerPrefs.DeleteKey(sceneKey);
        PlayerPrefs.DeleteKey(savePresentKey);
        LoadedData = null;
    }

    public bool LoadData()
    {

        if (PlayerPrefs.GetInt(savePresentKey) == 1)
        {
            LoadedData = new LoadedData();
            LoadedData.playerHealth = PlayerPrefs.GetFloat(playerHealthKey);
             LoadedData.directionState = PlayerPrefs.GetInt(directionStateKey);
            LoadedData.sceneIndex = PlayerPrefs.GetInt(sceneKey);
            return true;
        }
        return false;

    }

    public void SaveData(int sceneIndex, float playerHealth,int directionState)
    {
        if (LoadedData == null)
            LoadedData = new LoadedData();
        LoadedData.playerHealth = playerHealth;
        LoadedData.sceneIndex = sceneIndex;
        PlayerPrefs.SetFloat(playerHealthKey, playerHealth);
        PlayerPrefs.SetInt(sceneKey, sceneIndex);
        PlayerPrefs.SetInt(savePresentKey, 1);
    }

}

public class LoadedData
{
    public float playerHealth = -1;
    public int directionState=-1;
    public int sceneIndex = -1;
}