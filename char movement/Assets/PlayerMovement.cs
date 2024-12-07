using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 moveDir; public Animator animator;
   [SerializeField] private float Speed =10f;
   Vector3 MousePos; //public Rigidbody2D rb;
   public Transform Firepoint;
   
   private void InputMovement(){
   
    float moveX=0f;
    float moveY=0f;
    if (Input.GetKey(KeyCode.W)){moveY=+1f;}
    if (Input.GetKey(KeyCode.S)){moveY=-1f;}
    if(Input.GetKey(KeyCode.D)){moveX=+1f;}
    if (Input.GetKey(KeyCode.A)){moveX=-1f;}
   
 moveDir= new Vector2(moveX,moveY).normalized;
  animator.SetFloat("Xvalue",moveDir.x);
  animator.SetFloat("Yvalue",moveDir.y);
  animator.SetFloat("Speed",moveDir.sqrMagnitude);
   
   }
   private void DoMovement(){
 transform.position+= moveDir * Speed* Time.deltaTime;
 //rb.velocity=new Vector3(moveDir.x,moveDir.y) * Speed* Time.deltaTime;
   }
   
   private void Update() {
    InputMovement();
    MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
   }
   private void FixedUpdate() {
    DoMovement();
    Vector2 aimDir= (MousePos - Firepoint.position).normalized;
    float aimAngle= Mathf.Atan2(aimDir.y,aimDir.x)*Mathf.Rad2Deg-90f;
    Firepoint.rotation=Quaternion.Euler(new Vector3(0, 0, aimAngle));
   }
   }
