using UnityEngine;
using System.Collections;

public class PlayerColorChange : MonoBehaviour
{
    public healthMain healthMain; public bool isInvincible = false; // Tracks if the player is invincible

    public float invincibilityDuration = 5f; // Duration of the invincibility in seconds

    
    // Array of colors representing the available player colors
    private Color[] availableColors = { Color.red, Color.blue, Color.green, Color.white };
    private int currentColorIndex = 0;

    private Renderer playerRenderer;

    void Start()
    {
        // Get the Renderer component of the player
        playerRenderer = GetComponent<Renderer>();

        // Set the initial color
        UpdateColor();
    }

    void Update()
    {
        HandleColorChangeInput();
        if(isInvincible==true){
            ActivateInvincibility();
        }
    }

    private void HandleColorChangeInput()
    {
        // Check for input to change color
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Go to the next color in the array
            currentColorIndex = (currentColorIndex + 1) % availableColors.Length;
            UpdateColor();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            // Go to the previous color in the array
            currentColorIndex = (currentColorIndex - 1 + availableColors.Length) % availableColors.Length;
            UpdateColor();
        }
    }

    // Method to update the player's color
    private void UpdateColor()
    {
        if (playerRenderer != null)
        {
            // Get the current color from the array
            Color currentPlayerColor = availableColors[currentColorIndex];

            // Apply the color to the player's material
            playerRenderer.material.color = currentPlayerColor;
        }
    }

    // Method to compare the player's color with the enemy's color
    public bool CompareColors(Color playerColor, Color enemyColor)
    {
        // Directly compare Color values
        return playerColor == enemyColor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object is an enemy
        IEnemy enemy = other.GetComponent<IEnemy>();
        Renderer enemyRenderer = other.GetComponent<Renderer>();

        if (enemy != null && enemyRenderer != null)
        {
            // Get the player's current color
            Color playerColor = playerRenderer.material.color;

            // Get the enemy's current color
            Color enemyColor = enemyRenderer.material.color;

            // Compare player's color to enemy's color
            if (CompareColors(playerColor, enemyColor))
            {
                enemy.TakeDamage(1);
                Debug.Log("Correct color! Enemy took damage.");
            }
            else
            {
                Debug.Log($"Incorrect color: Player color {playerColor} vs Enemy color {enemyColor}");
                healthMain.TakeDamage(1);
            }
        }
    }
     // Method to activate invincibility
    public void ActivateInvincibility()
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }

    // Coroutine to handle invincibility
    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        Debug.Log("Player is now invincible!");

        // Optionally, change the player's appearance to indicate invincibility
        playerRenderer.material.color = Color.yellow; // Example: Change color to yellow

        // Wait for the specified duration
        yield return new WaitForSeconds(invincibilityDuration);

        isInvincible = false;
        Debug.Log("Player is no longer invincible.");

        // Revert to the original color
        UpdateColor();
    }
}

