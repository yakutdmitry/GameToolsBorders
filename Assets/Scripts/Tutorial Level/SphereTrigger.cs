using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    [SerializeField] private bool isPressed;
    [SerializeField] private GameObject platform;

    private void Start()
    {
        platform = GameObject.Find("FlyingPlatform");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Movable") && !isPressed)
        {
            // collision.gameObject.transform.Translate(0, -1, 0);
            isPressed = true;
            // transform.Translate(0, -2, 0);
            platform.transform.Translate(0, 15, 0);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Movable") && isPressed)
        {
            isPressed = false;
            // transform.Translate(0, 1, 0);
            platform.transform.Translate(0, -15, 0);
        }
        
    }
}
