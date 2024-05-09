using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputsManager _inputsManager;
    private PlayerLocomotion _playerLocomotion;
    private void Awake()
    {
        _inputsManager = GetComponent<InputsManager>();
        _playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        _inputsManager.HandleAllInputs();  
    }

    private void FixedUpdate()
    {
        _playerLocomotion.HandleAllMovement();
    }
}
