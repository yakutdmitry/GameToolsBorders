using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    private InputsManager _inputsManager;
    private Rigidbody playerRigidbody;
    private Transform cameraObject;
    private Vector3 moveDirection;
    

    [SerializeField] private float MovementSpeed;
    [SerializeField] private float RotationSpeed;

    private void Awake()
    {
        _inputsManager = GetComponent<InputsManager>();
        playerRigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * _inputsManager.VerticalInput;
        moveDirection = moveDirection + cameraObject.right * _inputsManager.HorisontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * MovementSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 TargetDirection = Vector3.zero;

        TargetDirection = cameraObject.forward * _inputsManager.VerticalInput;
        TargetDirection = TargetDirection + cameraObject.right * _inputsManager.HorisontalInput;
        TargetDirection.Normalize();
        TargetDirection.y = 0;

        if (TargetDirection == Vector3.zero)
        {
            TargetDirection = transform.forward;
        }

        Quaternion TargerRotation = Quaternion.LookRotation(TargetDirection);
        Quaternion PlayerRotation = Quaternion.Slerp(transform.rotation, TargerRotation, RotationSpeed * Time.deltaTime);

        transform.rotation = PlayerRotation;
        
        
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }
}
