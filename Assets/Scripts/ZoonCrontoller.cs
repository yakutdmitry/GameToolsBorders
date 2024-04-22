using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoonCrontoller : MonoBehaviour
{
    private CinemachineVirtualCamera _cm;
    [SerializeField] private float _maxFOV, _minFOW;
    private void Start()
    {
        _cm = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y < 0 & _cm.m_Lens.FieldOfView < _maxFOV & _cm.m_Lens.FieldOfView >= _minFOW)
        {
            _cm.m_Lens.FieldOfView += 1;
        }

        if (Input.mouseScrollDelta.y > 0 & _cm.m_Lens.FieldOfView > _minFOW & _cm.m_Lens.FieldOfView <= _maxFOV)
        {
            _cm.m_Lens.FieldOfView -= 1;
        }
    }
}
