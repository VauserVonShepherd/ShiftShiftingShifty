using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileObject : MonoBehaviour {
    public float damage = 0.1f;

    public void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<BasicAI>() && !other.GetComponent<ProjectileObject>())
        {
            Destroy(gameObject);
        }

        if (other.GetComponent<PlayerHealth>())
        {
            other.GetComponent<PlayerHealth>().TakeInstantDamage(damage);
        }
    }
}
