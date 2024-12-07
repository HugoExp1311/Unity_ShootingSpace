using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class movement : MonoBehaviour
{
    private const float SPEED=10f; float timer=0f; 
    //private const float dashDistance=5f;
     //float dashCD=5f;
   private Camera mainCamera; Vector3 targetPosition;
    public Rigidbody2D rb; PauseMenu pauseMenu;
    public bool isAttachToMouse=true;public bool lockMouseToSavedPosition; 
    private void Start() {
        EnableMovement();
        pauseMenu=FindObjectOfType<PauseMenu>();
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
      
    
    }
    private void Update()
    {
       
        // using mouse cursor to move
        if(isAttachToMouse && Time.timeScale==1){
 Cursor.visible=false;
            /*if (lockMouseToSavedPosition) //if onclick continue
            {
              StartCoroutine(LockMouseToSavedPosition());  
                lockMouseToSavedPosition = false;
            }*/
          
           
         Vector3  cursorPosition=Input.mousePosition;
         //cursorPosition.z=0;  chay duoc nhung hoi nhanh
         cursorPosition.z=-mainCamera.transform.position.z;
       
     
 targetPosition = mainCamera.ScreenToWorldPoint(cursorPosition);
         Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, SPEED * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
        
            
        
        // cach 2 khong duoc:Cursor.postion=speed;   no physic no collider
        //transform.position=Camera.main.ScreenToWorldPoint(cursorPosition);}


         //  cach 3 lo lo lung lung:       rb = GetComponent<Rigidbody2D>();
//Vector3 worldPosition = Camera.main.ScreenToWorldPoint(cursorPosition);
//Vector3 velocity = (worldPosition - transform.position).normalized * SPEED;
//rb.velocity = velocity;}
        }}
        IEnumerator LockMouseToSavedPosition()
    {
        Vector3  cursorPosition=  ES3.Load<Vector3>("savePos");
         transform.position=cursorPosition;
         yield return new WaitForSeconds(.5f);
      
    }
    
    
private void DisableMovement(){
    rb.bodyType=RigidbodyType2D.Static;
}
private void EnableMovement(){
    rb.bodyType=RigidbodyType2D.Dynamic;
}
private void OnEnable() {
    healthMain.OnDeath+=DisableMovement;
}
private void OnDisable() {
    healthMain.OnDeath-=DisableMovement;
}

    }
    
/* private void HandleMovement(){
   
    float moveX=0f;
    float moveY=0f;
    if (Input.GetKey(KeyCode.W)){moveY=+1f;}
    if (Input.GetKey(KeyCode.S)){moveY=-1f;}
    if(Input.GetKey(KeyCode.D)){moveX=+2f;}
    if (Input.GetKey(KeyCode.A)){moveX=-2f;}

 Vector3 moveDir= new Vector3(moveX,moveY).normalized;
 transform.position+= moveDir * SPEED* Time.deltaTime;
 if(Input.GetKeyDown(KeyCode.Space)){
    if(timer<dashCD){timer+=.1f;}
    else{
         transform.position+= moveDir * dashDistance;
         //Instantiate(DashEffect,transform.position,Quaternion.identity);
         timer=0f;
 } 
 }}}  */
 