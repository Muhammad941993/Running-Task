using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (x > 0)
        {
            transform.position += new Vector3(x * Time.deltaTime,0,0);
        }else if(x < 0)
        {
            transform.position += new Vector3(x * Time.deltaTime, 0, 0);
        }

    }


}
