using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class newDialog : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] line;
    private int index;
    public float textSpeed=10f;
    [SerializeField] private DialogManager dialogManager;

    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        textComponent.text = string.Empty;
        dialogManager.StartDialog();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == line[index])
                NextLine();
            else
            {
                StopAllCoroutines();
                textComponent.text = line[index];
            }
        }
    }

    void NextLine()
    {
        if (index < line.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(typeLine());
        }
        else
        { 
            dialogManager.EndDialog();
            
        }
    }

    IEnumerator typeLine()
    {
        foreach (char c in line[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    
}
