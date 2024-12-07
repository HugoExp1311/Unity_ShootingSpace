using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class FloatReference : MonoBehaviour
{
    public bool UseConst;
    public float ConstValue;
    public FloatVariables variables;
    public float Value{
get{ return UseConst ? ConstValue : variables.value; }
    }
}
