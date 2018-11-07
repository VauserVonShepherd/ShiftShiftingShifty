using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenArmJoint : Breakable {

    public override void TakeDamageBySpeed(float speed)
    {
        base.TakeDamageBySpeed(speed);

        GetComponent<Renderer>().material.color = new Color(
            GetComponent<Renderer>().material.color.r,
            GetComponent<Renderer>().material.color.b,
            GetComponent<Renderer>().material.color.g,
        (health / 100));

        //(100 - health) / 100);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<PlayerHealth>())
        {
            TakeDamageBySpeed(collision.relativeVelocity.magnitude);
        }
    }
}
