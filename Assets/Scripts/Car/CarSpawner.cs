using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Transform carSpawnPoint;
    [SerializeField] private GameObject carPrefab;

    private Coroutine spawnCoroutine;
    // TODO 오브젝트풀화 예정

    private void Update()
    {
        SpawnCar();
    }

    private void SpawnCar()
    {
        if (spawnCoroutine != null) return;

        spawnCoroutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        GameObject createdCar = Instantiate(carPrefab, carSpawnPoint);
        createdCar.transform.position = carSpawnPoint.position;
        createdCar.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        yield return new WaitForSeconds(3f);

        spawnCoroutine = null;
    }

}