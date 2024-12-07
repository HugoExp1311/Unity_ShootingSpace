using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(menuName ="PowUp/HealthBuff")]
public class HealthBuff : PowerUpEffect
{
    public float amount;
     TextMeshProUGUI skillText;
    public override void Apply(GameObject target)
    {
        target.GetComponent<healthMain>().healthMax+=amount;
        target.GetComponent<healthMain>().health+=amount;
        Debug.Log("da them "+amount);
    }

}
