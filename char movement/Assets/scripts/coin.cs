using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class coin : MonoBehaviour,IntfCollectable
{  public static event HandleCollectCoin OnCollectCoin;
    public delegate void HandleCollectCoin(ItemData itemData); 
    public AudioClip sound;
    public Rigidbody2D rb;
    float speed=5f;
    public ItemData coinData;
    
    
    // float timer=4f; float count=0f;
   /* void start(){
        float x=Random.Range(0,2)==0?1:-1;
        float y=Random.Range(0,2)==0?1:-1;
        rb.velocity=new Vector2(x*speed,y*speed);
    }
    void Update(){ 
         transform.Rotate(new Vector3(0,0,20)*2,Space.World);
        count+=.1f; if(count%2==0){
        rb.AddForce(new Vector2(1,0)*speed);}
        else{rb.AddForce(new Vector2(-1,0)*speed);}
    } **Edit: June 2023: what the fuck is this??????*/
    void Start()
    {    
        
        rb.GetComponent<Rigidbody2D>();
        
        rb.velocity=new Vector3(0,-1,0)*speed;
    }
    /* void OnTriggerEnter2D(Collider2D hitInfo){
inventory inventory=hitInfo.GetComponent<inventory>();
if(inventory!=null){
   bool picked = inventory.pickItem(gameObject);
    if(picked){
        AudioManager.instance.playClip(sound);
    Destroy(gameObject);}
}} */

    public void Collect(){
        
      AudioManager.instance.playClip(sound);
        
        OnCollectCoin?.Invoke(coinData);
        Destroy(gameObject);
    }
}
  
        


