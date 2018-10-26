using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : Breakable {
    public enum AIState { IDLE, MOVE, DIE, ATTACK, CHASE };
    public AIState currentState = AIState.IDLE;

    [SerializeField]
    float speed;
    protected Transform movementTarget;

    [SerializeField]
    protected float detectionRange = 5;
    [SerializeField]
    protected float engageRange = 5;

    protected virtual void Update()
    {
        RunState();
    }

    public void RunState()
    {
        switch (currentState)
        {
            case AIState.IDLE:
                IDLE();
                break;

            case AIState.MOVE:
                MOVE();
                break;

            case AIState.DIE:
                DIE();
                break;

            case AIState.ATTACK:
                ATTACK();
                break;

            case AIState.CHASE:
                CHASE();
                break;
        }
    }

    protected virtual void IDLE()
    {

    }

    protected virtual void MOVE()
    {

    }

    protected virtual void DIE()
    {

    }
    protected virtual void ATTACK()
    {

    }

    protected virtual void CHASE()
    {
        MoveTo();
        
    }

    public void MoveTo()
    {
        if (Vector3.Magnitude(transform.position - PlayerBehaviour.instance.transform.position) > engageRange)
            transform.Translate((movementTarget.position - transform.position).normalized * Time.deltaTime * speed);
    }
}
