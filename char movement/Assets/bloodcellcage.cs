using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class bloodcellcage : MonoBehaviour,IEnemy
{
    private float health=150; //int shieldStack=3;
    DialogueSystemTrigger dialogueSystemTrigger;
    
    private void Awake() {
      dialogueSystemTrigger=gameObject.GetComponentInParent<DialogueSystemTrigger>();
    }
    public void TakeDamage(float damage){
      
   health-=damage;

 
  if (health<=0f){ health=0f;

  dialogueSystemTrigger.enabled=!dialogueSystemTrigger.enabled;
  if(dialogueSystemTrigger.enabled==false){
    EnableFuckingDialog();
  }
    if (health==0f && dialogueSystemTrigger.enabled==true){
     
        gameObject.SetActive(false);
        }
    }
    }
     

    void EnableFuckingDialog(){
        dialogueSystemTrigger.enabled=true;

    }
}
