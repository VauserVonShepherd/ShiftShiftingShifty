using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleAI : BasicAI {
    public Scriptable_AttackType attack;

    public float cooldown = 1;
    private bool canAttack = true;

    protected override void Update()
    {
        base.Update();
    }

    protected override void IDLE()
    {
        base.IDLE();
        if(Vector3.Magnitude(transform.position - PlayerBehaviour.instance.transform.position) < detectionRange)
        {
            currentState = AIState.CHASE;
            movementTarget = PlayerBehaviour.instance.transform;
        }
    }

    protected override void CHASE()
    {
        base.CHASE();

        if (attack && canAttack && Vector3.Magnitude(transform.position - PlayerBehaviour.instance.transform.position) < engageRange)
        {
            currentState = AIState.ATTACK;
        }
    }

    protected override void ATTACK()
    {
        base.ATTACK();

        attack.FireProjectile(transform.position, (transform.position - PlayerBehaviour.instance.transform.position).normalized);

        currentState = AIState.CHASE;
        StartCoroutine(RunCooldown());
        canAttack = false;
    }

    private IEnumerator RunCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        currentState = AIState.ATTACK;
        canAttack = true;
    }
}
