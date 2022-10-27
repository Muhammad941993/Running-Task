using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float TimeBetweenWaves = 2f;
    [SerializeField] List<Transform> SpawnPoints;
    float timerdecrease;
    Pool pool;
    // Start is called before the first frame update
    void Start()
    {
        pool = FindObjectOfType<Pool>();
        timerdecrease = TimeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        ResetSpawnTime();
    }

    void ResetSpawnTime()
    {
        timerdecrease -= Time.deltaTime;
        if(timerdecrease < 0)
        {
            timerdecrease = TimeBetweenWaves;
            SpwanWave();
        }
    }


    void SpwanWave()
    {
       
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            int SpawnPrecentage = Random.Range(0, 10);
            if(SpawnPrecentage < 4)
            {
               GameObject g = pool.Get();
                if(g != null)
                {
                    g.transform.position = SpawnPoints[i].position;
                    g.SetActive(true);
                }
               
            }
        }
    }
}
