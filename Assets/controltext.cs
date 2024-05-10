using UnityEngine;
using TMPro;

public class DisableTextAfterDelay : MonoBehaviour
{
    public TextMeshProUGUI textToDisable;

    private bool playerInputDetected = false;

    void Update()
    {
        // Check if player input is detected for the first time
        if (!playerInputDetected && Input.anyKeyDown)
        {
            playerInputDetected = true;

            // Call the DisableText method after 5 seconds from the first player input
            Invoke("DisableText", 5f);
        }
    }

    void DisableText()
    {
        // Check if the TextMeshPro game object is valid
        if (textToDisable != null)
        {
            // Disable the TextMeshPro game object
            textToDisable.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("TextMeshPro game object not assigned!");
        }
    }
}
