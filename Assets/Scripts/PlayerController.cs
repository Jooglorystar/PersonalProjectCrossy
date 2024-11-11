using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float moveDistance = 1f;
    Vector3 moveValue;


    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;   
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();

        if (moveInput.magnitude > 1f) return;

        if (context.started)
        {
            moveValue = moveInput * moveDistance;
        }

        if (context.canceled)
        {
            Debug.Log(moveInput);
            transform.position += new Vector3(moveValue.x, 0, moveValue.y);
            _camera.transform.position += new Vector3(moveValue.x, 0, moveValue.y);
            moveInput = Vector2.zero;
        }
    }
}
