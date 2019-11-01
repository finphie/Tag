using System;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class FreeLookUserInput : MonoBehaviour
{
    void Start()
        => CinemachineCore.GetInputAxis = GetInputAxis;

    float GetInputAxis(string axisName)
    {
        return Input.GetMouseButton(0) && axisName.StartsWith("Mouse", StringComparison.Ordinal)
            ? Input.GetAxis(axisName)
            : 0;
    }
}
