using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    
      private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.TryGetComponent<healthMain>(out healthMain healthMain)){
           
        }
}}
