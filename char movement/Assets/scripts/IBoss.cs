using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IBoss
{
    void Die();

    event Action BossDied;
}