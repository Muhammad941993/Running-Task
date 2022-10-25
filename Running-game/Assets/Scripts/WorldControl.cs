using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldControl : MonoBehaviour
{
  
   
    PlayerControl player;
    Rotation rotation;
    Movement movement;

   
    private void Awake()
    {
        player = FindObjectOfType<PlayerControl>();
        rotation = GetComponent<Rotation>();
        movement = FindObjectOfType < Movement >();
    }
   

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(rotation.RotateTheWorld(-1));
            StartCoroutine(FlipGameStyle());
           
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(rotation.RotateTheWorld(1));
          StartCoroutine(FlipGameStyle());
           
        }
    }



    // flip the game world gravity and control of movement
    IEnumerator FlipGameStyle() 
    {
        player.FlipTheGravity();
        yield return new WaitForSeconds(.5f);
        movement.FlipMovement();
    }

   
  

   
}
