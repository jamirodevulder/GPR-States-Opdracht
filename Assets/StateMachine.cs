using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine : MonoBehaviour
{
    private States currentState;
    public Wander _wander;
    public playerDetection _playerDetection;
    public Chase _chase;
    public Attack _attack;



    private enum States
    {
        WANDER,
        ATTACK,
        CHASE
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = States.WANDER;
        _chase.onTargetNotSet += SetWander;
        _playerDetection.onPlayerDetection += SetChase;
        _attack.onPlayerAttack += SetAttack;
        _attack.onPlayerIsNotAttacking += SetChase;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case States.WANDER:
                _wander.CheckDestenation();
                break;
            case States.ATTACK:
                
                break;
            case States.CHASE:
                _chase.ChaseNow();
                break;
        }    
    }
    public void SetChase()
    {
        currentState = States.CHASE;
    }
    public void SetWander()
    {
        currentState = States.WANDER;
    }
    public void SetAttack()
    {
        currentState = States.ATTACK;
    }
}
