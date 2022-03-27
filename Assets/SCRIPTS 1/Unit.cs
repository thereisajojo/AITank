﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int health = 100;
    public GameObject deadEffect;

    public void ApplyDamage(int damage)
    {
        if (health > damage)
        {
            health -= damage;
        }
        else
        {
            Destruct();
        }
    }

    public void Destruct()
    {
        if (deadEffect != null)
        {
            Instantiate(deadEffect, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
