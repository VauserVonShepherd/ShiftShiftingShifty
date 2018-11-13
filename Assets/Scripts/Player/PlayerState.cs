using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    public static PlayerState instance;

    public int JumpBeforeFree = 0;

    public Vector3 stuckedPosition;

    private int currJumpCount = 0;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if(JumpBeforeFree > 0)
        {
            transform.position = Vector3.Lerp(transform.position, stuckedPosition, Time.deltaTime * 10f);

            if (Vector3.Magnitude(transform.position - stuckedPosition) > 2)
            {
                UnStuck();
            }
        }
    }

    public void JumpCheck()
    {
        ++currJumpCount;
        if(currJumpCount >= JumpBeforeFree)
        {
            if (Vector3.Magnitude(transform.position - stuckedPosition) > 0.05f)
            {
                currJumpCount = 0;
                JumpBeforeFree = 0;
                GetComponent<PlayerBehaviour>().JumpModifier = 100;
                GetComponent<PlayerState>().stuckedPosition = Vector3.zero;
                UnStuck();
            }
        }
    }

    public void Stuck(int JumpCount,float drag, float angularDrag)
    {
        JumpBeforeFree = JumpCount;

        GetComponent<Rigidbody>().drag = drag;
        GetComponent<Rigidbody>().angularDrag = angularDrag;
    }

    public void UnStuck()
    {
        GetComponent<Rigidbody>().drag = 0;
        GetComponent<PlayerBehaviour>().speedModifier = 100;
        JumpBeforeFree = 0;
    }
}
