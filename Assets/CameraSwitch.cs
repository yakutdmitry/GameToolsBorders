using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject TurnOn;
    [SerializeField] private GameObject TurnOff;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TurnOff.SetActive(false);
            TurnOn.SetActive(true);
        }
    }
}
