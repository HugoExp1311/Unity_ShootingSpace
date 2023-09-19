using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPbar : MonoBehaviour
{   public Slider slider;
    public healthMain hp;
    public Image fillImage;
    // Start is called before the first frame update
    
    void Update() {
        if(slider.value<=slider.minValue){fillImage.enabled=false;}
        
        if(slider.value>slider.minValue && !fillImage.enabled){fillImage.enabled=true;}
        
        float fillHP=hp.health/hp.healthMax;
        slider.value=fillHP;
    }

}
