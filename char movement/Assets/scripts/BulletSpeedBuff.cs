using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(menuName ="PowUp/BulletSpeedBuff")]
public class BulletSpeedBuff : PowerUpEffect
{
   public float amount;
     TextMeshProUGUI skillText;
    public override void Apply(GameObject target)
    {
       
        
        target.GetComponent<fireBullet>().bonusSpeed+=amount;
                

    }

}
