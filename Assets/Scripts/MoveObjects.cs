using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    [SerializeField] private bool _isMoving;
    [SerializeField] private GameObject _Movable;
    [SerializeField] private LayerMask _racycastMovement;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // finds the object we are going to move by checking its tag
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.gameObject.CompareTag("Movable"))
                {
                    _Movable = hit.transform.gameObject;
                    _isMoving = true;

                    _Movable.layer = 6;
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (_isMoving)
            {
                RaycastHit hit;
                
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f, _racycastMovement))
                {
                    if (_Movable != null)
                    {
                        Vector3 movablePos = new Vector3(hit.point.x, hit.point.y + 1.6f, hit.point.z);
                        _Movable.transform.position = movablePos;

                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_isMoving)
            {
                _Movable.layer = 0;
                _Movable = null;
                _isMoving = false;
            }
        }
        
    }
}
