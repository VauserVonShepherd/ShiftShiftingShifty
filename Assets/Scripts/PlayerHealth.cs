using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    //1 = 100%
    public float health = 1;

    [SerializeField]
    private float damageModifier = 0.025f;

    public void TakeDamage(float velocity)
    {
        if (velocity > 5)
        {
            float damageTaken = velocity * damageModifier;

            health -= damageTaken;

            transform.localScale = new Vector3(health, health, health);

            if (health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
