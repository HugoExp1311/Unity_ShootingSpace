using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandle : MonoBehaviour
{ //attach this script to all bosses gameobject
    public static event Action BossDied;
    public void Died(){
        BossDied?.Invoke();
    }


}

