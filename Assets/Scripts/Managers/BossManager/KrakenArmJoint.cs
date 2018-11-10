using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenArmJoint : Breakable {
    public KrakenArm armController;
    float maxHealth;
    
    public KrakenArmJoint nextJoint, previousJoint;

    private void Start()
    {
        armController = transform.parent.GetComponent<KrakenArm>();

        maxHealth = health;
    }

    public override void TakeDamageBySpeed(float speed)
    {
        base.TakeDamageBySpeed(speed);

        GetComponent<Renderer>().material.color = new Color(
            GetComponent<Renderer>().material.color.r,
            GetComponent<Renderer>().material.color.b,
            GetComponent<Renderer>().material.color.g,
        (health / maxHealth));
        
    }

    public override void Die()
    {
        if (GetComponent<HingeJoint>())
        {
            //Destroy(GetComponent<HingeJoint>().connectedBody.GetComponent<HingeJoint>());
            Destroy(GetComponent<HingeJoint>());

            if (GetComponent<BasicAI>())
            {
                Destroy(GetComponent<BasicAI>());
            }

            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().velocity -= Vector3.forward * 20;

            armController.armlast.GetComponent<Rigidbody>().useGravity = true;

            armController.ReorganizeArm();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerHealth>())
        {
            TakeDamageBySpeed(collision.relativeVelocity.magnitude);
            collision.collider.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
