using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private CarSO carData;

    private Rigidbody _rigidbody;
    [SerializeField]private MeshRenderer _bodyMeshRenderer;

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

        Material material = carData.carMaterials[Random.Range(0, carData.carMaterials.Length)];
        Material[] materials = _bodyMeshRenderer.materials;
        materials[0] = material;
        _bodyMeshRenderer.materials = materials;

        
        // _bodyMeshRenderer.materials[0] = material;
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