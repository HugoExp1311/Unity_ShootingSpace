using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinUI : MonoBehaviour
{
   // simpleManager simpleManager; 
   inventory Inventory;
    private void Start() {
        //simpleManager=FindObjectOfType<simpleManager>();
        Inventory=FindObjectOfType<inventory>();
        
//      DontDestroyOnLoad(gameObject);
      GetComponent<TextMeshProUGUI>().text= $"{Inventory.coinCount}"; //mix string text with int variables

   }
  
  //public float levelcount; //bien nay la UI thoi, bien chinh la int currentLevel trong healthmain
   public void UpdateCoin(){ //unity event skill manager, duoc  dung trong healthmain
GetComponent<TextMeshProUGUI>().text= $"{Inventory.coinCount}"; //mix string text with int variables
   }
}
