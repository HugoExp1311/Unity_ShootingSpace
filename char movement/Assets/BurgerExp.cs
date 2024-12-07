
using UnityEngine;

public class BurgerExp : MonoBehaviour
{
    [SerializeField] int expAmount=1; 
    
    private TurnBig turnBig1;
    private void Start() {
        turnBig1=FindObjectOfType<TurnBig>();
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {
    healthMain health=hitInfo.GetComponent<healthMain>();
        if(health!=null ){ 
            //AudioManager.instance.playClip(sound);
          
          //  health.AddBurgerExp(expAmount);
        
            turnBig1.AddMana(1);
            Debug.Log("+1mana");
           
        }
        
            Destroy(gameObject);
        }
}
