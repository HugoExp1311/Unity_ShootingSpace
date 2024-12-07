using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    public Color startColor=Color.blue;
    public Color endColor=Color.black;
    [Range(0,10)]
    public float speed=1;
    Renderer ren;
    private void Awake() {
        ren=GetComponent<Renderer>();
    }

    // Update is called once per frame
    public void Blink()
    {
        for(int i=0;i<10;i++)
        ren.material.color=Color.Lerp(startColor,endColor,Mathf.PingPong(Time.time*speed,1));
    }
   private void Update() {
            ren.material.color=Color.Lerp(startColor,endColor,Mathf.PingPong(Time.time*speed,1));

   }
}
