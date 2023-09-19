using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogManager : MonoBehaviour
{
    public UnityEvent onDialogStart;
    public UnityEvent onDialogEnd; public bool Dialog;
    public enemy_spawn spawn;


    public void StartDialog()
    {   Dialog=true;
        onDialogStart.Invoke();
       
    }

    public void EndDialog()
    {
       spawn=FindObjectOfType<enemy_spawn>();
        onDialogEnd.Invoke();
       Dialog=false;
       
    }
}
