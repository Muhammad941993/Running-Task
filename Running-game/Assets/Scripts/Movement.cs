using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float rotationDgree = 20;
    int CurrentMoveDirection = 1;
    Rotation rotation;

    void Awake()
    {
        rotation = GetComponent<Rotation>();
      
    }

    // horizontal movement of the player with body rotaion while moving 
    public void HorizontalMovement(float direction, float speed)
    {
        if (direction > 0)
        {
            
            MoveLeftAndRight(direction, speed , CurrentMoveDirection);

            rotation.RotatePlayerBodyByDgree(rotationDgree, rotationSpeed);
        }
        else if (direction < 0)
        {
            MoveLeftAndRight(direction, speed , CurrentMoveDirection);

            rotation.RotatePlayerBodyByDgree(-rotationDgree, rotationSpeed);
        }

       // reset rotation after moving
       rotation.ResetPlayerRotation(10);
    }


    private void OnCollisionEnter(Collision collision)
    {

        // reset rotation if get hit by platform
        transform.rotation = rotation.SetRotation();
    }

    // flip player movement right with left
    public void FlipMovement()
    {
         CurrentMoveDirection *= -1;
       
    }

    // moving the character Horizontal movement 
    public void MoveLeftAndRight(float Direction, float speed , int flipMove)
    {
        transform.position += new Vector3(Direction * Time.deltaTime * speed * flipMove, 0, 0);
    }

}
