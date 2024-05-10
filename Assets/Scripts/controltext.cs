using System.Security.Cryptography;
using UnityEngine;
using TMPro;

public class DisableTextAfterDelay : MonoBehaviour
{
    private bool playerInputDetected = false;

    void Update()
    {
        // Check if player input is detected for the first time
        if (!playerInputDetected && Input.anyKeyDown)
        {
            playerInputDetected = true;

            // Call the DisableText method after 5 seconds from the first player input
            Destroy(gameObject, 5f);
        }
    }

    
}
