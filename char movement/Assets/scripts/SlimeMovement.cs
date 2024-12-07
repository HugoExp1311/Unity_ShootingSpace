using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public float moveSpeed = 3f; 
    private Vector3 moveDir; 
    private bool facingRight = true; 
    //public Animator animator; 

    private void InputMovement()
    {
        float moveX = 0f;
        float moveY = 0f;

        // Get input
        if (Input.GetKey(KeyCode.W)) { moveY = +1f; }
        if (Input.GetKey(KeyCode.S)) { moveY = -1f; }
        if (Input.GetKey(KeyCode.D)) { moveX = +1f; }
        if (Input.GetKey(KeyCode.A)) { moveX = -1f; }

        // Normalize the movement direction
        moveDir = new Vector2(moveX, moveY).normalized;

      
    }

    private void DoMovement()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        // Check if we need to flip the sprite based on movement direction
        if ((moveDir.x > 0 && !facingRight) || (moveDir.x < 0 && facingRight))
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Invert the facing direction
        facingRight = !facingRight;

        // Flip the sprite by inverting the x-scale
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void Update()
    {
        // Handle movement input and movement
        InputMovement();
    }

    private void FixedUpdate()
    {
        // Apply movement in FixedUpdate for smooth physics updates
        DoMovement();
    }
}
