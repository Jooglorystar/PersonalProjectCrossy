using UnityEngine;

[CreateAssetMenu(fileName = "DefaultCarSO", menuName = "CarSO", order = 0)]
public class CarSO : ScriptableObject
{
    [Header("Car Speed")]
    public float maxCarSpeed;
    public float minCarSpeed;

    [Header("Car Size")]
    public float maxCarSize;
    public float minCarSize;

    [Header("Car Color")]
    public Material[] carMaterials;
}
