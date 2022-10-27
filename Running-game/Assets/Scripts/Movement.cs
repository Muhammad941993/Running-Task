using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float rotationDgree = 15;
    int CurrentMoveDirection = 1;
    Rotation rotation;
    bool InPlatform = true;
    void Awake()
    {
        rotation = GetComponent<Rotation>();
      
    }

    private void Update()
    {
        if (!InPlatform) rotation.transform.rotation = rotation.SetRotation();
    }

    // horizontal movement of the player with body rotaion while moving 
    public void HorizontalMovement(float direction, float speed)
    {
        if (direction > 0)
        {
            
            MoveLeftAndRight(direction, speed , CurrentMoveDirection);

            if(InPlatform)
            rotation.RotatePlayerBodyByDgree(rotationDgree, rotationSpeed);
        }
        else if (direction < 0)
        {
            MoveLeftAndRight(direction, speed , CurrentMoveDirection);

            if (InPlatform)
                rotation.RotatePlayerBodyByDgree(-rotationDgree, rotationSpeed);
        }

       // reset rotation after moving
       rotation.ResetPlayerRotation(30);
    }



    private void OnCollisionEnter(Collision collision)
    {

        // reset rotation if get hit by platform
        //transform.rotation = rotation.SetRotation();
        InPlatform = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        InPlatform = false;
    }
    // flip player movement right with left
    public void FlipMovement()
    {
         CurrentMoveDirection *= -1;
        transform.rotation = rotation.SetRotation();
    }

    // moving the character Horizontal movement 
    public void MoveLeftAndRight(float Direction, float speed , int flipMove)
    {
        transform.position += new Vector3(Direction * Time.deltaTime * speed * flipMove, 0, 0);
    }

}
