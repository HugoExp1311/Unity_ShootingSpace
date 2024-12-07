using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(menuName ="PowUp/DamageBuff")]
public class DamageBuff : PowerUpEffect
{
    public int amount;
     TextMeshProUGUI skillText;
    public override void Apply(GameObject target)
    {
       
        target.GetComponent<fireBullet>().bonusDamage+=amount;
              // tang dame cho chi bullet type 1 do script shoot nam o bullt type 1
              //need rework
        

    }

}
