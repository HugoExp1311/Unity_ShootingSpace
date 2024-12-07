using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class onDIalogEnd : MonoBehaviour
{
    public bool isOnconversationEnd=false;
public bool isConversation;
    public void OnConversationEnd(Transform actor) {
         Debug.Log(string.Format("Ending conversation with {0}", actor.name));
isOnconversationEnd=true;
isConversation=false;    
}
public void OnConversationStart(Transform actor) {
    isConversation=true; 
} 
}
