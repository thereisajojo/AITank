using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosionEffect;
    public float explosionTimeUp;
    public float explosionRadius;
    public float explosionForce;
    public int damage;
    void OnCollisionEnter()
    {
        GameObject obj= Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;
        Destroy(gameObject);
        Destroy(obj, explosionTimeUp);

        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius);
        if (cols.Length > 0)
        {
            for(int i = 0; i < cols.Length; i++)
            {
                Rigidbody r = cols[i].GetComponent<Rigidbody>();
                if (r != null)
                {
                    r.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }

                Unit u= cols[i].GetComponent<Unit>();
                if (u != null)
                {
                    u.ApplyDamage(damage);
                }

            }
        }
    }
}
