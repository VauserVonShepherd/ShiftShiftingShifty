using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileAttack", menuName = "AttackType/Projectile", order = 1)]
public class Scriptable_AttackType : ScriptableObject {
    public GameObject Projectile;
    public float Speed;

    public void FireProjectile(Vector3 pos, Vector3 direction)
    {
        GameObject projectile = Instantiate(Projectile, pos, Quaternion.identity);

        projectile.GetComponent<Rigidbody>().velocity = -direction * Speed;
    }
}
