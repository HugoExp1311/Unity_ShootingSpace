using UnityEngine;
using System.Collections;

public class SlimeColorRandomizer : MonoBehaviour, IEnemy
{
    // Array of possible colors for the enemy
    public Color[] enemyColors = { Color.red, Color.blue, Color.green, Color.white };
    private Color currentColor;
    
    public float colorChangeInterval = 2f; // Time in seconds for each color before switching
    private Renderer enemyRenderer;
    private bool isChangingColor = false;         
  


    public float health = 1f;
    [SerializeField] private int expAmount;

    private void Start()
    {
          Vector3 localScale = transform.localScale;
        localScale.x *= -1;
               transform.localScale = localScale;
        isChangingColor = false;
        enemyRenderer = GetComponent<Renderer>();
        expAmount = 1;

        // Assign a random initial color from the enemyColors array
        currentColor = enemyColors[Random.Range(3, enemyColors.Length)];
        ApplyColorToSprite(currentColor);

        // Start color changing coroutine if this enemy is a "random color" type
        if (IsRandomColorType())
        {
            transform.localScale *= 1.5f; // Make it larger to indicate special type
            StartCoroutine(ChangeColor());
        }
    }

    private void ApplyColorToSprite(Color color)
    {
        // Apply the color to the sprite renderer
        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = color;
        }
    }

    private bool IsRandomColorType()
    {
        // Decide if this enemy should be of the "random color" type.
        // Here, we assume that an enemy with color white represents "random color" (as an example).
        return currentColor == Color.white;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;

            ExpManager.instance.AddExp(expAmount);
            Destroy(gameObject); // Destroy the enemy when health reaches 0
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        healthMain healthMain = other.GetComponent<healthMain>();
        if (healthMain != null)
        {
            TakeDamage(1);
        }
    }

    private IEnumerator ChangeColor()
    {
        isChangingColor = true;

        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(colorChangeInterval);

            // Change to a new random color
            UpdateColor();
        }
    }

    private void UpdateColor()
    {
        // Assign a new random color from the available colors in the array
        currentColor = enemyColors[Random.Range(0, enemyColors.Length)];
        ApplyColorToSprite(currentColor);
    }
}
