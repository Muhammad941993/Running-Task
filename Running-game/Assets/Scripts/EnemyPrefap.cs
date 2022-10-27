using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefap : MonoBehaviour
{
    [SerializeField] Color[] colors = new Color[3];
    [SerializeField] float Speed = 10;
    float disablePoint = -11;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<MeshRenderer>().material.color = colors[ Random.Range(0, 3)];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, -Speed * Time.deltaTime));
        DisableEnemy();
    }


    void DisableEnemy()
    {
        if(transform.position.z < disablePoint)
        {
            gameObject.SetActive(false);
        }
    }
}
