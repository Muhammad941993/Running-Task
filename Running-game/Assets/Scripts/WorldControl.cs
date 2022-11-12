using System.Collections;
using UnityEngine;

public class WorldControl : MonoBehaviour
{


    PlayerControl player;
    Rotation rotation;
    GameObject platform;
    float timebetweenFlip;
    [SerializeField] float FlipTimer = 1;
    Vector3 QoffsetDistance;
    Vector3 EoffsetDistance;
    private void Awake()
    {
        QoffsetDistance = new Vector3(2, -2, 0);
        EoffsetDistance = new Vector3(-2, -2, 0);
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
            StartCoroutine(SetThePlayerAsCenter(-1 , EoffsetDistance));
            
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(SetThePlayerAsCenter(1 , QoffsetDistance));
            
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

    IEnumerator SetThePlayerAsCenter(int dir , Vector3 offset)
    {

        transform.position = player.transform.position + offset;
        platform.transform.SetParent(transform);
        yield return StartCoroutine(rotation.RotateTheWorld(dir));
        platform.transform.SetParent(null);
        timebetweenFlip = FlipTimer;
    }

  

}
