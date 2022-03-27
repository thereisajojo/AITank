using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITank : Unit
{
    public float moveSpeed;
    public float attackRange;
    public GameObject player;
    public float shootCoolDown;
    public float timer;

    public TankWeapon tw;

    void Start()
    {
        tw = GetComponent<TankWeapon>();
    }

    void FixedUpdate()
    {   
        timer += Time.fixedDeltaTime;

        if (player == null) return;

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist > attackRange)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        transform.LookAt(player.transform.position);

        if (timer > shootCoolDown)
        {
            tw.Shoot();
            timer = 0f;
        }

    }
}
