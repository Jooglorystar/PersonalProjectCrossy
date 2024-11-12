using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private CarSO carData;

    private Rigidbody _rigidbody;
    private Material _material;

    private float carSpeed;
    private float carSize;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        carSpeed = Random.Range(carData.minCarSpeed, carData.maxCarSpeed);
        carSize = Random.Range(carData.minCarSize, carData.maxCarSize);

        gameObject.transform.localScale = new Vector3(carSize, carSize, carSize);
    }

    private void LateUpdate()
    {
        _rigidbody.velocity = transform.forward.normalized * carSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("CarRemover"))
        {
            Destroy(gameObject);
        }
    }
}