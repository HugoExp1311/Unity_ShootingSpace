using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelupUI : MonoBehaviour
{
   private void Start() {
//      DontDestroyOnLoad(gameObject);
      GetComponent<TextMeshProUGUI>().text= $"Lv.{healthMain.currentLevel}"; //mix string text with int variables

   }
   [SerializeField] private healthMain healthMain;
  //public float levelcount; //bien nay la UI thoi, bien chinh la int currentLevel trong healthmain
   public void IncrementLevel(){ //unity event skill manager, duoc  dung trong healthmain
GetComponent<TextMeshProUGUI>().text= $"Lv.{healthMain.currentLevel}"; //mix string text with int variables
   }
  
}
