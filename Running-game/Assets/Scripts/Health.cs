using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{

  public event Action OnHealthDecrease;
    public event Action OnPlayerDeath;

    int PlayerHealth;
    bool Dead;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
      
        OnPlayerDeath += PlayerIsDed;
        PlayerHealth = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreseHealth(int Point)
    {
        PlayerHealth -= Point;
        OnHealthDecrease();
        StartCoroutine(HitBehaviour());

        if (PlayerHealth <= 0)
        {
            Dead = true;
            OnPlayerDeath();
            return;
        }
    }

    public int GetHealth()
    {
        return PlayerHealth;
    }

    public bool IfIsDead() { return Dead; }

    IEnumerator HitBehaviour()
    {
        
        anim.SetBool("hit", true);
        yield return new WaitForSeconds(.4f);
        anim.SetBool("hit", false);
    }
    void PlayerIsDed()
    {
        anim.SetBool("dead" , true);
    }
}
