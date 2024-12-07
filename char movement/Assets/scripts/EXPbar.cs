using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPbar : MonoBehaviour
{
     private Slider slider;
    public healthMain exp;
    public Image fillImage;
    // Start is called before the first frame update
    
     private void Awake() {
        slider=GetComponent<Slider>(); // cach private ko loi
        
    }
    void Update() {
        if(slider.value<=slider.minValue){fillImage.enabled=false;}
        
        if(slider.value>slider.minValue && !fillImage.enabled){fillImage.enabled=true;}
        
        float fillEXP=exp.currentExp/exp.maxExp;
        
        slider.value=fillEXP;
    }

}
