using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attack : MonoBehaviour
{

    public delegate void OnPlayerAttack();
    public event Action onPlayerAttack;

    public delegate void OnPlayerIsNotAttacking();
    public event Action onPlayerIsNotAttacking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            print("ik doe jou pijn");
            onPlayerAttack?.Invoke();
        }
        else
        {
            onPlayerIsNotAttacking?.Invoke();
        }
    }
}
