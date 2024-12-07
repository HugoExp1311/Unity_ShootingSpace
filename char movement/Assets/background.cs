using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{   
    public float deadZone=-5f;//float timer=0f;  
    public float amount=20f;
    public Vector3 defaultPos; public bool isDouble=false;
    private void Start() {
        transform.position=defaultPos;
    }
    void Update()
    {   Vector3 moveDir=new Vector3(0,-1);
    transform.position+=moveDir*2*Time.deltaTime;
if(transform.position.y<deadZone){
    
    Instantiate(gameObject,transform.position*amount,Quaternion.identity);
    //transform.position+=new Vector3(0,-deadZone);
    isDouble=true;}
    if(isDouble==true){ 
    Destroy(gameObject); 
    isDouble=false; 
    transform.position=defaultPos;}  
}
   
    
} 

    

