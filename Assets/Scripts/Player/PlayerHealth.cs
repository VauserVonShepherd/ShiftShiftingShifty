using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public static PlayerHealth instance;

    //1 = 100%
    public float health = 1;

    [SerializeField]
    private float damageModifier = 0.007f;

    private void Awake()
    {
        instance = this;
    }

    public void TakeDamage(float velocity)
    {
        if (velocity > 10)
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

    public void IncreaseHealth(float healthVal)
    {
        if (health < 1)
        {
            health += healthVal;
        }
        transform.localScale = new Vector3(health, health, health);
    }
}
