using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPath : MonoBehaviour
{
    public float speed = 5f; // Speed of the bullet
    public float radius = 3f; // Radius of the circular path

    private float angle = 0f; // Current angle

    void Update()
    {
        // Increment the angle based on the speed and time
        angle += speed * Time.deltaTime;

        // Calculate the new position using sine and cosine
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        // Update the bullet's position
        transform.position = new Vector3(x, y, transform.position.z);
    }

    }

