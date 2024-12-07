using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquarePath : MonoBehaviour
{
        
    public float speed = 5f; // Speed of the bullet
    public float sideLength = 3f; // Length of each side of the square

    private Vector3 startPos; // Starting position
    private int currentEdge = 0; // Current edge of the square
    private float traveledDistance = 0f; // Distance traveled along the current edge

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the distance to move this frame
        float distanceToMove = speed * Time.deltaTime;
        traveledDistance += distanceToMove;

        if (traveledDistance >= sideLength)
        {
            // Move to the next edge
            traveledDistance -= sideLength; // Remainder distance on the next edge
            currentEdge = (currentEdge + 1) % 4; // Loop back to the first edge after the last one
            startPos = transform.position;
        }

        // Determine direction based on the current edge
        Vector3 direction = Vector3.zero;
        switch (currentEdge)
        {
            case 0:
                direction = Vector3.right;
                break;
            case 1:
                direction = Vector3.down;
                break;
            case 2:
                direction = Vector3.left;
                break;
            case 3:
                direction = Vector3.up;
                break;
        }

        // Move the bullet in the current direction
        transform.position = startPos + direction * traveledDistance;
    }
}
