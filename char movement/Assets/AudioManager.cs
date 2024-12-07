using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    public AudioSource audioSource;
    
    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Persist the instance across scenes
        }
        else if (instance != this)
        {
            Destroy(gameObject);  // Destroy duplicate instances
        }
    }

    // Play a one-shot audio clip
    public void playClip(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    // Play an audio clip and wait for the specified duration before stopping it
    public IEnumerator WaitPlaySound(AudioClip waitClip, float waitDuration)
    {
        // Ensure the audio source is not null and the clip is assigned
        if (audioSource != null && waitClip != null)
        {
            // Play the audio clip
            audioSource.clip = waitClip;
            audioSource.Play();
        }

        // Wait for the specified duration
        yield return new WaitForSeconds(waitDuration);

        // Stop the audio source after waiting (optional)
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // Method to start the WaitAndPlaySound coroutine
    public void WaitAndPlaySound(AudioClip waitClip, float waitDuration)
    {
        StartCoroutine(WaitPlaySound(waitClip, waitDuration));
    }
}
