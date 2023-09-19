using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waves_test : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public float activationDelay = 1.0f;

    private void Start()
    {
        StartCoroutine(ActivateObjectsSequentially());
    }

    private IEnumerator ActivateObjectsSequentially()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(activationDelay);
        }
    }
}
        
    

