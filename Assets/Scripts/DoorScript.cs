using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private ButtonScript button1;
    [SerializeField] private ButtonScript button2;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (button1.isPressed && button2.isPressed)
        {
            _animator.SetBool("activated", true);
        }
        else
        {
            _animator.SetBool("activated", false);
        }
    }
}
