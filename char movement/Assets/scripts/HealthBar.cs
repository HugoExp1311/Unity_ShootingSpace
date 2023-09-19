using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{   private Transform bar;
    public HealthSystem healthSystem;
    public void Setup(HealthSystem healthSystem){
        this.healthSystem=healthSystem;
        
    }
  
    public void Setsize(float SizeNormalize)
    {
        transform.Find("Bar").localScale = new Vector3(SizeNormalize,1f);
    }
    public void SetColor(Color color){
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color=color;
    }
}