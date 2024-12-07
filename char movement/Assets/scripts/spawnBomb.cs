using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBomb : MonoBehaviour
{ //curved path
  
    public float frequency = 2f; // How fast the bullet moves in the sine wave pattern
    public float magnitude = 0.5f; // How wide the sine wave is
    public float maxDistance = 5f; // Maximum distance before changing direction
    public float decreaseY = 0.1f;
    private float traveledDistance = 0f;

    private Vector3 startPos;
[SerializeField] private float speed=2f; 
 private bool movingRight = true;
    [SerializeField] private float damage=1000f; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
         
    }

    void Update()
    {
        // Calculate the distance to move this frame
        float distanceToMove = speed * Time.deltaTime;

        // Update the traveled distance
        traveledDistance += distanceToMove;

        // Check if the bullet has reached the maximum distance
        if (traveledDistance >= maxDistance)
        {
            // Change direction to the left and decrease y position slightly
            movingRight = false;
            traveledDistance = 0f; // Reset traveled distance after changing direction
            startPos = new Vector3(transform.position.x, transform.position.y - decreaseY, transform.position.z);
        }

        // Move the bullet forward or backward based on the direction
        if (movingRight)
        {
            transform.position += transform.right * distanceToMove;
        }
        else
        {
            transform.position -= transform.right * distanceToMove;
        }

        // Apply the sine wave offset
        Vector3 offset = transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
        transform.position = startPos + (movingRight ? transform.right : -transform.right) * traveledDistance + offset;
    }

         void OnTriggerEnter2D(Collider2D hitInfo) {
        healthMain health= hitInfo.GetComponent<healthMain>();
        if(health != null){ health.TakeDamage(damage);
            Destroy(gameObject);}
        }
}

