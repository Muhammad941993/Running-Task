using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float rotationDgree = 15;
    int CurrentMoveDirection = 1;
    Rotation rotation;
    bool InPlatform = true;
    GameObject startPos;
    [SerializeField] float CurrentDistanceInY = 0;
    float lastYdistance = 0;
    Animator anim;
    void Awake()
    {
        startPos = GameObject.Find("platform");
        rotation = GetComponent<Rotation>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        FallingControl();
    }


    // if player fall reset rotaion 
    // calculate y distance
    void FallingControl()
    {
        if (!InPlatform)
        {
            rotation.transform.rotation = rotation.SetRotation();
            CurrentDistanceInY = startPos.transform.position.y - transform.position.y;
        }
    }

    // return if the player start fall away to decrease health
    public bool FallingAway()
    {
        if (InPlatform) return false;

        if (GetFallingDistance() - lastYdistance > 15)
        {
            lastYdistance = GetFallingDistance();

            return true;
        }
        return false;
    }



    // horizontal movement of the player with body rotaion while moving 
    public void HorizontalMovement(float direction, float speed)
    {
        if (direction > 0)
        {

            MoveLeftAndRight(direction, speed, CurrentMoveDirection);

            if (InPlatform)
                rotation.RotatePlayerBodyByDgree(rotationDgree, rotationSpeed);
        }
        else if (direction < 0)
        {
            MoveLeftAndRight(direction, speed, CurrentMoveDirection);

            if (InPlatform)
                rotation.RotatePlayerBodyByDgree(-rotationDgree, rotationSpeed);
        }

        // reset rotation after moving
        rotation.ResetPlayerRotation(20);
    }


    public int GetFallingDistance()
    {
        return (int)CurrentDistanceInY;
    }
    private void OnCollisionEnter(Collision collision)
    {
        InPlatform = true;
        CurrentDistanceInY = 0;
        rotation.transform.rotation = rotation.SetRotation();
        anim.SetBool("fall", false);
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.transform.CompareTag("platform"))
        {
            anim.SetBool("fall", true);
            InPlatform = false;
        }
       
    }


    // moving the character Horizontal movement 
    public void MoveLeftAndRight(float Direction, float speed, int flipMove)
    {
        transform.position += new Vector3(Direction * Time.deltaTime * speed * flipMove, 0, 0);
    }

}
