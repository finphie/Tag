using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CinemachineFreeLook))]
[RequireComponent(typeof(PlayerInput))]
public class CameraController : MonoBehaviour
{
    CinemachineFreeLook cinemachine;

    public Vector2 Look { get; private set; }

    public void OnLook(InputValue value)
        => Look = value.Get<Vector2>();

    void Start()
        => cinemachine = GetComponent<CinemachineFreeLook>();

    void Update()
    {
        cinemachine.m_XAxis.m_InputAxisValue = Look.x;
        cinemachine.m_YAxis.m_InputAxisValue = Look.y;
    }
}