using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{
   public GameObject EnemyPrefab;
   public int PrefabNumber;
}
public class Pool : MonoBehaviour
{
    [SerializeField] PoolItem Enemy;
   
    [SerializeField] List<GameObject> EnemyList;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine( InstantiatePool());
    }

    // Update is called once per frame
    

    IEnumerator InstantiatePool()
    {
        for (int i = 0; i < Enemy.PrefabNumber; i++)
        {
           
            GameObject E = Instantiate(Enemy.EnemyPrefab,transform);
            E.SetActive(false);
            EnemyList.Add(E);
            yield return null;
        }
    }

    public GameObject Get()
    {
        foreach(GameObject g in EnemyList)
        {
            if (!g.activeInHierarchy)
                return g;
        }
        return null;
    }
}
