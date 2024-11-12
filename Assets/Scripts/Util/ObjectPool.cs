using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        public Queue<GameObject> poolQueue;
    }

    public List<Pool> pools;
    public Dictionary<string, Pool> PoolDict;

    private void Awake()
    {
        PoolDict = new Dictionary<string, Pool>();
        foreach (var pool in pools)
        {
            pool.poolQueue = new Queue<GameObject>();
            for(int i = 0;i<pool.size;i++)
            {
                GameObject obj = Instantiate(pool.prefab, transform);
                obj.SetActive(false);
                pool.poolQueue.Enqueue(obj);
            }
            PoolDict.Add(pool.tag, pool);
        }
    }

    // 오브젝트 풀에서 생성
    public GameObject SpawnFromPool(string tag)
    {
        if(!PoolDict.ContainsKey(tag)) return null;

        GameObject obj = PoolDict[tag].poolQueue.Dequeue();
        PoolDict[tag].poolQueue.Enqueue(obj);
        obj.SetActive(true);

        return obj;
    }
}
