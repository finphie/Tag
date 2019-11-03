using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraController : MonoBehaviour
{
    CinemachineFreeLook cinemachine;

    public Vector2 Look { get; private set; }

    public void OnLook(InputAction.CallbackContext context)
        => Look = context.ReadValue<Vector2>();

    void Start()
        => cinemachine = GetComponent<CinemachineFreeLook>();

    void Update()
    {
        cinemachine.m_XAxis.m_InputAxisValue = Look.x;
        cinemachine.m_YAxis.m_InputAxisValue = Look.y;
    }
}