using UnityEngine;
using UnityEngine.UI;

public class SkillCd : MonoBehaviour
{
    public Image image;
    public KeyCode getBig; 
    public bool isCooldown = false;
    public float cooldownDuration = 10f; // Duration in seconds
    private float cooldownTimer = 0f; // Timer to track cooldown progress

    private void Start() 
    {
        image.fillAmount = 0; // Start with no cooldown
    }

    private void Update() 
    {
        if(Input.GetKeyDown(getBig) && !isCooldown) 
        {
            StartCooldown();
        }

        if(isCooldown)
        {
            HandleCooldown();
        }
    }

    private void StartCooldown() 
    {
        isCooldown = true;
        cooldownTimer = cooldownDuration; // Start the cooldown timer
        image.fillAmount = 1; // Start the cooldown with the image fully filled
    }

    private void HandleCooldown() 
    {
        cooldownTimer -= Time.deltaTime; // Reduce the cooldown timer

        // Update the fill amount based on the remaining cooldown time
        image.fillAmount = cooldownTimer / cooldownDuration;

        // Check if the cooldown is finished
        if(cooldownTimer <= 0) 
        {
            EndCooldown();
        }
    }

    private void EndCooldown() 
    {
        isCooldown = false;
        image.fillAmount = 0; // Reset the image fill amount
    }
}
