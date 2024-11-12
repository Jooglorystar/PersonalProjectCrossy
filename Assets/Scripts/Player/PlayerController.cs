using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    float moveDistance = 1f;
    Vector3 moveValue;

    private Animator animator;
    private static int animatorMove = Animator.StringToHash("Move");
    private static int animatorDamage = Animator.StringToHash("Damage");

    private Camera _camera;
    private CoinCollecting coin;

    public LayerMask layerMask;

    private Coroutine moveAnimationCoroutine;

    private void Awake()
    {
        _camera = Camera.main;
        coin = GetComponent<CoinCollecting>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        GameManager.Instance.player = this;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.isPlaying)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();

            if (context.started)
            {
                moveValue = new Vector3(moveInput.x, 0, moveInput.y) * moveDistance;
            }

            if (context.canceled)
            {
                Move(moveInput);
            }
        }
    }

    private void Move(Vector2 moveInput)
    {
        Rotate(moveValue);
        if (!IsBlock(moveValue))
        {
            moveAnimationCoroutine = StartCoroutine(MoveAnimation());
            coin.CollectCoin(moveValue);
        }

        moveInput = Vector2.zero;
    }

    private IEnumerator MoveAnimation()
    {
        animator.SetTrigger(animatorMove);

        yield return new WaitForSeconds(0.3f);

        transform.position += moveValue;
        _camera.transform.position += moveValue;

        moveAnimationCoroutine = null;
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
        // 차와 충돌 시 Die 메서드 호출
        if (other.gameObject.layer == LayerMask.NameToLayer("Car"))
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        animator.SetTrigger(animatorDamage);
        Debug.Log("Die");
        GameManager.Instance.isPlaying = false;

        yield return new WaitForSeconds(1.5f);

        gameObject.SetActive(false);
    }
}
