using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
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
        // GameObject createdCar = Instantiate(carPrefab, transform);
        GameObject createdCar = GameManager.Instance.objectPool.SpawnFromPool("Car");

        createdCar.transform.position = transform.position;
        //createdCar.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        createdCar.transform.rotation = transform.rotation;


        yield return new WaitForSeconds(Random.Range(2f, 3f));

        spawnCoroutine = null;
    }

}