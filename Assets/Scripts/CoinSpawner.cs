using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private int coinPositionX = 2;
    private int coinPositionZ = 1;

    public int coinCount;

    // �ߺ������� ���� ���� ����Ʈ;
    private List<Vector3> usedPosition;
    
    private void Start()
    {
        usedPosition = new List<Vector3>();

        for (int i = 0; i < coinCount; i++)
        {
            GameObject coin = Instantiate(coinPrefab, transform);

            Vector3 newPosition;

            do
            {
                newPosition = SetCoinPosition();
            }
            while (usedPosition.Contains(newPosition));

            // �ߺ����� ���� ��ǥ�� ��� ������ ��ǥ�� �ϰ�, usedPosition�� �ִ´�
            coin.transform.localPosition = newPosition;
            usedPosition.Add(newPosition);
        }
        
    }

    // ���� ��ǥ ���ϴ� �޼���
    private Vector3 SetCoinPosition()
    {
        return new Vector3(Random.Range(-coinPositionX, coinPositionX + 1), 0f, Random.Range(-coinPositionZ, coinPositionZ + 1));
    }
}
