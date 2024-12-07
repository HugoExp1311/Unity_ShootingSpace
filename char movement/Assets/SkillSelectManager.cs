using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillSelectManager : MonoBehaviour
{
    public PowerUpEffect[] buffs; // Array of Scriptable Objects
    public TMP_Text[] buttonTexts; // Array of TextMeshPro components on buttons
    public Button[] buttons;
    [SerializeField] private  GameObject player;
    public GameObject pauseMenu;
    public bool isPause;  private CanvasManager canvasManager; private static SkillSelectManager instance;

    private List<int> selectedBuffIndices; // List to track selected buff indices
    private HashSet<BuffType> selectedBuffTypes; // HashSet to track selected buff types

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
} */
    private void Start()
    {
        player= GameObject.FindWithTag("Player");
        canvasManager=FindObjectOfType<CanvasManager>(); // find component and make ref of canvas manager
        pauseMenu.SetActive(false);
        selectedBuffIndices = new List<int>(); // Initialize the list
        selectedBuffTypes = new HashSet<BuffType>(); // Initialize the HashSet
        UpdateButtonTexts();
    }

    public void PauseGame()
    {
        canvasManager.ShowSKillChoiceCanvas();
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        SetCharacterMovementEnabled(false);
        Time.timeScale = 0f;
        isPause = true;

    }

    public void ResumeGame()
    {
        
        
        Cursor.visible = true;
        pauseMenu.SetActive(false);
        SetCharacterMovementEnabled(true);
        Time.timeScale = 1f;
        isPause = false;
    }
public void MakePauseActive(){
    canvasManager.turnOnPauseCanvas();
}
    public void SetCharacterMovementEnabled(bool enabled)
    {
        movement characterMovement = FindObjectOfType<movement>();

        if (characterMovement != null)
        {
            characterMovement.isAttachToMouse = enabled;
        }
    }

    public void GetRandomBuff0()
    {
        buffs[selectedBuffIndices[0]].Apply(player);
    }

    public void GetRandomBuff1()
    {
        buffs[selectedBuffIndices[1]].Apply(player);
    }

    public void GetRandomBuff2()
    {
        buffs[selectedBuffIndices[2]].Apply(player);
    }

    public void UpdateButtonTexts()
    {
        selectedBuffIndices.Clear(); // Clear the list at the start
        selectedBuffTypes.Clear(); // Clear the HashSet at the start

        // Shuffle the buffOptions array to get a random order
        ShuffleArray(buffs);

        // Ensure no duplicate buffs are selected
        int index = 0;
        for (int i = 0; i < buffs.Length && index < buttonTexts.Length; i++)
        {
            if (!selectedBuffTypes.Contains(buffs[i].buffType))
            {
                selectedBuffIndices.Add(i);
                selectedBuffTypes.Add(buffs[i].buffType);
                buttonTexts[index].text = buffs[i].name;
                index++;
            }
        }

        // Fill remaining buttons with "No Buff" if not enough unique buffs
        while (index < buttonTexts.Length)
        {
            buttonTexts[index].text = "No Buff";
            index++;
        }
    }

    // Fisher-Yates shuffle algorithm
    private void ShuffleArray<T>(T[] array)
    {
        int n = array.Length;
        for (int i = n - 1; i > 0; i--)
        {
            float randomTime = Time.time * 1000f;
            Random.InitState((int)(randomTime % int.MaxValue));

            int j = Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
