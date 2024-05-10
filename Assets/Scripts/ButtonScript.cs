using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool isPressed;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Movable"))
        {
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("Movable"))
        {
            isPressed = false;
        }
    }
}
