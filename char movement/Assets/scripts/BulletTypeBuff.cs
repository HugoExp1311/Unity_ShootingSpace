using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "PowUp/BulletTypeBuff")]
public class BulletTypeBuff : PowerUpEffect
{
    public GameObject bullet; // The new bullet type to be applied

    public override void Apply(GameObject target)
    {
        fireBullet fireBulletComponent = target.GetComponent<fireBullet>();

    
            if (fireBulletComponent.Bullet != bullet)
            {
                
                fireBulletComponent.ChangeBulletPrefab(bullet);
            
            }
            else
            {
                fireBulletComponent.directionState++;
                //Debug.Log("Trung nhau");
                
                
            }

            // Optionally, you can add code here to update any other relevant properties or UI elements
        }
      
    
}
