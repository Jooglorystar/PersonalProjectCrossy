using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    private void LateUpdate()
    {
        _rigidbody.velocity = transform.forward.normalized * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("CarRemover"))
        {
            Destroy(gameObject);
        }
    }
}
