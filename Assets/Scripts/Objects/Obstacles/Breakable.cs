using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {
    public float health = 100;

    public virtual void TakeDamageBySpeed(float speed)
    {
        health -= speed;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
