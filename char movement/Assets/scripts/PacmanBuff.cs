using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(menuName ="PowUp/PacmanBuff")]
public class PacmanBuff : PowerUpEffect
{
    public float amount; //atkspd=0.1f only choice
     TextMeshProUGUI skillText;
    public override void Apply(GameObject target)
    {
       
        target.GetComponent<PlayerColorChange>().isInvincible=true;
                

    }

}
