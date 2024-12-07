
using UnityEngine; using TMPro;

public class ManaUI : MonoBehaviour
{
      TurnBig turnBig;
    private void Start() {
//      DontDestroyOnLoad(gameObject);
turnBig=FindObjectOfType<TurnBig>();
      GetComponent<TextMeshProUGUI>().text= $"{turnBig.manaBar}"; //mix string text with int variables

   }
  
  //public float levelcount; //bien nay la UI thoi, bien chinh la int currentLevel trong healthmain
   public void UpdateShield(){ //unity event skill manager, duoc  dung trong healthmain
GetComponent<TextMeshProUGUI>().text= $"{turnBig.manaBar}"; //mix string text with int variables
   }
}
