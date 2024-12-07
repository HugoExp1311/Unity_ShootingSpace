using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockChildrenTransform : MonoBehaviour
{
    
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    void Start()
    {
        // Store the initial transform properties relative to the world
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialScale = transform.localScale;
    }

    void Update()
    {
        // Override the transform properties to keep them constant
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        transform.localScale = initialScale;
    }

}
