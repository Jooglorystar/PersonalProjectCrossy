using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float moveDistance = 1f;
    Vector3 moveValue;

    private Animator animator;
    private static int jump = Animator.StringToHash("Jump");

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        animator = GetComponentInChildren<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();

        if (context.started)
        {
            moveValue = moveInput * moveDistance;
        }

        if (context.canceled)
        {
            transform.position += new Vector3(moveValue.x, 0, moveValue.y);
            animator.SetTrigger(jump);
            Rotate(moveValue); 

            _camera.transform.position += new Vector3(moveValue.x, 0, moveValue.y);
            moveInput = Vector2.zero;
        }
    }

    private void Rotate(Vector3 moveValue)
    {
        
        if (moveValue.y < 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, moveValue.x * 90f, 0f);
        }
    }
}
