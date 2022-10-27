using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 10;
    Movement movement;
    float CurrentScaleY = 1;
   
    
    void Awake()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
       movement.HorizontalMovement(x , PlayerSpeed);

        
    }

    // flip the gravity in the game
    public void FlipTheGravity()
    {
        // flip the player scale with gravity
        transform.localScale = new Vector3(1, CurrentScaleY *= -1 , 1);

        // flip gravity
        Physics.gravity *= -1;
    }





}
