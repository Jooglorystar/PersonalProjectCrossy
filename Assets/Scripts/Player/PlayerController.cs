using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float moveDistance = 1f;
    Vector3 moveValue;

    private Animator animator;
    private static int jump = Animator.StringToHash("Jump");
    private static int damage = Animator.StringToHash("Damage");

    private Camera _camera;

    public LayerMask layerMask;

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
            moveValue = new Vector3(moveInput.x, 0, moveInput.y) * moveDistance;
        }

        if (context.canceled)
        {
            Rotate(moveValue);
            if (!IsBlock(moveValue))
            {
                transform.position += moveValue;
                _camera.transform.position += moveValue;

            }
            //animator.SetTrigger(jump);

            moveInput = Vector2.zero;
        }
    }

    private void Rotate(Vector3 moveValue)
    {

        if (moveValue.z < 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, moveValue.x * 90f, 0f);
        }
    }

    private bool IsBlock(Vector3 moveInput)
    {
        Vector3 moveDir = new Vector3(moveInput.x, 0, moveInput.z).normalized;

        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), moveDir);
      
        if (Physics.Raycast(ray, 1.5f, layerMask))
        {
            Debug.Log("is blocked");
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger(damage);
        Debug.Log("Die");
    }
}
