using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float PlayerSpeed = 10;
    Movement movement;
    Health health;
    Animator anim;
    void Awake()
    {
        health = GetComponent<Health>();
        movement = GetComponent<Movement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IfIsDead()) return;

        float x = Input.GetAxis("Horizontal");
       movement.HorizontalMovement(x , PlayerSpeed);

        if (movement.FallingAway())
        {
            health.DecreseHealth(1);
            
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            health.DecreseHealth(1);
        }
    }

   


}
