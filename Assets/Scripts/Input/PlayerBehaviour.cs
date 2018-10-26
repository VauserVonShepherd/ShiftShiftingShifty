using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    public static PlayerBehaviour instance;

    public float speedModifier = 100; //100 = 100%, 50 = 50% speed
    public float JumpModifier = 100; //100 = 100% Strength, 50% = 50% Jump strength
    private bool IsJumpCharging = false;
    
    [SerializeField]
    private float m_RotationSpeed = 1;
    [SerializeField]
    private float m_JumpForce = 5;
    private Rigidbody m_Rigid;

    [SerializeField]
    private Material playerMat;

    private void Awake()
    {
        instance = this;
        m_Rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float hSpeed = getHSpeed() * (0.01f * speedModifier);

        //m_Rigid.AddTorque(new Vector3(0,0,-hSpeed));

        if (GetComponent<PlayerChangeShape>().shapeVal == 0)
        {
            //if square then half the rotation force
            m_Rigid.AddTorque(new Vector3(0, 0, -hSpeed * 0.5f));
        }
        else
        {
            m_Rigid.AddTorque(new Vector3(0, 0, -hSpeed));
        }

        if (PlayerInput.instance.JumpInput)
        {
            IsJumpCharging = true;

            JumpModifier += Time.deltaTime * 30;
            GetComponent<Rigidbody>().drag += Time.deltaTime * 10;
            GetComponent<Rigidbody>().angularDrag += Time.deltaTime * 10;

            playerMat.color = new Color(1, (200 - JumpModifier) /200, (200 - JumpModifier) / 200);
            if(JumpModifier >= 200)
            {
                Jump();
                GetComponent<Rigidbody>().drag = 0;
                GetComponent<Rigidbody>().angularDrag = 0.05f;
                PlayerInput.instance.JumpInput = false;
            }
        }
        
        if (IsJumpCharging && !PlayerInput.instance.JumpInput)
        {
            Jump();
            GetComponent<Rigidbody>().drag = 0;
            GetComponent<Rigidbody>().angularDrag = 0.05f;
        }
    }
    
    public float getHSpeed()
    {
        float hSpeed = PlayerInput.instance.GetHInput() * m_RotationSpeed;

        return hSpeed;
    }

    public void Jump()
    {
        m_Rigid.velocity = transform.up * m_JumpForce * (0.01f * JumpModifier);

        if(speedModifier < 100)
        {
            GetComponent<PlayerState>().JumpCheck();
        }

        if (JumpModifier >= 150)
        {
            GetComponent<PlayerHealth>().TakeInstantDamage((JumpModifier * 0.0005f));
        }

        JumpModifier = 100;
        IsJumpCharging = false;

        playerMat.color = new Color(1, 1, 1);
    }

    public void OnCollisionEnter(Collision collision)
    {
        GetComponent<PlayerHealth>().TakeDamage(collision.relativeVelocity.magnitude);

        if (collision.collider.GetComponent<Breakable>())
        {
            collision.collider.GetComponent<Breakable>().TakeDamageBySpeed(collision.relativeVelocity.magnitude);
        }
    }
}
