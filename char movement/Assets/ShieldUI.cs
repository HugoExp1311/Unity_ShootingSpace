using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldUI : MonoBehaviour
{
    [SerializeField] private healthMain healthMain;
    private void Start() {
//      DontDestroyOnLoad(gameObject);
      GetComponent<TextMeshProUGUI>().text= $"{healthMain.shieldStack}"; //mix string text with int variables

   }
  
  //public float levelcount; //bien nay la UI thoi, bien chinh la int currentLevel trong healthmain
   public void UpdateShield(){ //unity event skill manager, duoc  dung trong healthmain
GetComponent<TextMeshProUGUI>().text= $"{healthMain.shieldStack}"; //mix string text with int variables
   }
  
}
