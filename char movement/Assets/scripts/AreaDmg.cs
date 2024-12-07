using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDmg : MonoBehaviour
{
    [SerializeField] private float areadmg=1f;
     private void OnTriggerStay2D(Collider2D other) {
       healthMain healthMain=other.GetComponent<healthMain>();
       if(healthMain!=null){
        healthMain.TakeDamage(areadmg);
       }
    }

    /*private void OnEnable() {

        Invoke("Disable",2f);
    }
     void Disable(){
        gameObject.SetActive(false);    
    }
    
     private void OnDisable() {
        CancelInvoke();
    } */
}
