using UnityEngine;
using UnityEngine.InputSystem;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class PlayerController : MonoBehaviour
{
    ThirdPersonCharacter character;
    Transform mainCamera;

    public Vector2 Move { get; private set; }

    public bool Jump { get; private set; }

    public void OnMove(InputAction.CallbackContext context)
        => Move = context.ReadValue<Vector2>();

    public void OnJump(InputAction.CallbackContext _)
        => Jump = true;

    void Start()
    {
        if (Camera.main != null)
            mainCamera = Camera.main.transform;

        character = GetComponent<ThirdPersonCharacter>();
    }

    void FixedUpdate()
    {
        var forward = Vector3.Scale(mainCamera.forward, new Vector3(1, 0, 1)).normalized;
        var move = (Move.x * mainCamera.right) + (Move.y * forward);

        character.Move(move, false, Jump);
        Jump = false;
    }
}