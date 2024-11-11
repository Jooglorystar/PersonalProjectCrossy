using UnityEngine;

[CreateAssetMenu(fileName = "DefaultCarSO", menuName = "CarSO", order = 0)]
public class CarSO : ScriptableObject
{
    public float carSpeed;
    public float carSize;
    public Color carColor;
}
