using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatUI : MonoBehaviour
{
     [SerializeField] private simpleManager simpleManager; 
     
   private void Start() {
     simpleManager=FindObjectOfType<simpleManager>();
   }
     private void Update() {
         
      
      string statsText = $"HP: {simpleManager.currentHP}/{simpleManager.maxHP}\n" +
                           $"+FireRate: {simpleManager.bonusSpeed}\n" +
                            $"+Damage: {simpleManager.bonusDamage}\n" +
                             $"AtkSpd: {simpleManager.atkspd}\n"+
                           $"Bullet Tier: {simpleManager.directionState}";

        GetComponent<TextMeshProUGUI>().text = statsText;

   }
}
