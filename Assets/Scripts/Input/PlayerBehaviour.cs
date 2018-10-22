using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    public static PlayerBehaviour instance;

    [SerializeField]
    private float m_RotationSpeed = 1;
    [SerializeField]
    private float m_JumpForce = 5;
    private Rigidbody m_Rigid;

    private void Awake()
    {
        instance = this;
        m_Rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float hSpeed = getHSpeed();

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
            Jump();
        }
    }
    
    public float getHSpeed()
    {
        float hSpeed = PlayerInput.instance.GetHInput() * m_RotationSpeed;

        return hSpeed;
    }

    public void Jump()
    {
        m_Rigid.velocity = transform.up * m_JumpForce;
    }

    public void OnCollisionEnter(Collision collision)
    {
        GetComponent<PlayerHealth>().TakeDamage(collision.relativeVelocity.magnitude);
    }
}
