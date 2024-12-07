using UnityEngine;
using UnityEngine.UI;


public class SkillShowUI : MonoBehaviour
{
    public PowerUpEffect[] buffs; // Array of Scriptable Objects
public Button buttons;
public int n;
    public GameObject player;

    private void Start() {
        Button btn=buttons.GetComponent<Button>();
        btn.onClick.AddListener(AddSkill);
    }
    public void AddSkill(){
        
       //buffs[n].Apply(player);
Debug.Log("button has been CLICKED "+n+" times");
    }
    }

   

