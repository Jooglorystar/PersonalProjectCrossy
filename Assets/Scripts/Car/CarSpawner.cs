using System.Collections;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject carPrefab;

    private Coroutine spawnCoroutine;

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
        GameObject createdCar = GameManager.Instance.objectPool.SpawnFromPool("Car");

        createdCar.transform.position = transform.position;
        createdCar.transform.rotation = transform.rotation;

        // 랜덤간격 생성
        yield return new WaitForSeconds(Random.Range(2f, 3f));

        spawnCoroutine = null;
    }

}