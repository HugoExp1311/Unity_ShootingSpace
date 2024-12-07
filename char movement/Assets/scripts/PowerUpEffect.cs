using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpEffect : ScriptableObject
{ public BuffType buffType; // Add this line
    public abstract void Apply(GameObject target);
    
}
