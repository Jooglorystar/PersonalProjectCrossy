using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private int coinPositionX = 2;
    private int coinPositionZ = 1;

    public int coinCount;

    // 중복생성을 막기 위한 리스트;
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

            // 중복되지 않은 좌표일 경우 코인의 좌표로 하고, usedPosition에 넣는다
            coin.transform.localPosition = newPosition;
            usedPosition.Add(newPosition);
        }
        
    }

    // 랜덤 좌표 구하는 메서드
    private Vector3 SetCoinPosition()
    {
        return new Vector3(Random.Range(-coinPositionX, coinPositionX + 1), 0f, Random.Range(-coinPositionZ, coinPositionZ + 1));
    }
}
