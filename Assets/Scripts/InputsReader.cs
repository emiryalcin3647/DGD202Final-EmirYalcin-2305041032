using UnityEngine;
using UnityEngine.InputSystem;

public class InputsReader : MonoBehaviour
{
    private PlayerInput controls;
    private Vector2 moveInput;
    private PlayerMover mover;

    private void Awake()
    {
        controls = new PlayerInput();
        mover = GetComponent<PlayerMover>();

        controls.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        if (mover != null)
        {
            mover.Move(moveInput);
        }
    }
}
