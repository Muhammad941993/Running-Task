using System.Collections;
using UnityEngine;

public class WorldControl : MonoBehaviour
{


    PlayerControl player;
    Rotation rotation;
    GameObject platform;
    float timebetweenFlip;
    [SerializeField] float FlipTimer = 1;
    private void Awake()
    {
        player = FindObjectOfType<PlayerControl>();
        rotation = GetComponent<Rotation>();
        platform = GameObject.Find("platform");

        timebetweenFlip = FlipTimer;
    }


    // Update is called once per frame
    void Update()
    {
        if (!TimeToFlip()) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(SetThePlayerAsCenter(-1));
            
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(SetThePlayerAsCenter(1));
            
        }
    }

    bool TimeToFlip()
    {
        timebetweenFlip -= Time.deltaTime;
        if (timebetweenFlip < 0)
        {
          return true;
        }
        return false;
    }

    IEnumerator SetThePlayerAsCenter(int dir)
    {

        transform.position = player.transform.position + new Vector3(0, 2, 0);
        platform.transform.SetParent(transform);
        yield return StartCoroutine(rotation.RotateTheWorld(dir));
        platform.transform.SetParent(null);
        timebetweenFlip = FlipTimer;
    }

   
}
