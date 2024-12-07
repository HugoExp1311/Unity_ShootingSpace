using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GiftBox : MonoBehaviour,IEnemy
{
    [SerializeField] private GameObject[] Gift;
    [SerializeField] private float healthMax=20f;
   [SerializeField] private float health;
   private void Start() {
  health=healthMax;}
    public void TakeDamage(float damage){
         health-=damage;
    if (health<=0f){ health=0f;
    if (health==0f){ //spawner template idea
        int randGift= Random.Range(0,Gift.Length);
      GameObject chosenGift=Gift[randGift];
        Instantiate(chosenGift,transform.position,Quaternion.identity);
        Destroy(gameObject);
        }
    }}
    }

