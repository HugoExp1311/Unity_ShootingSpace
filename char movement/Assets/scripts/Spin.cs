using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]private float spinSpeed=2f;


    // Update is called once per frame
    void Update()
    {
         transform.Rotate(new Vector3(0,0,20)*spinSpeed,Space.World);
    }
}
