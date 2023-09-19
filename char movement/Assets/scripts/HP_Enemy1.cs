using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HP_Enemy1 : MonoBehaviour
{   public Slider slider;
    private IEnemy enemy;
    [SerializeField] private Transform target;
    public new Camera camera;
    [SerializeField] private Vector3 offset;
    // Start is called before the first frame update
     void Awake() {
        slider= GetComponent<Slider>();
    }
    public void UpdateHealthBar(float currentValue,float maxValue){
slider.value=currentValue/maxValue;
    }
private void Update() {
    transform.parent.rotation=camera.transform.rotation;
    transform.position=target.position+offset;
}
}
   