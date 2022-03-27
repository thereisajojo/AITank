using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon : MonoBehaviour
{
    public GameObject shell;
    public float shootPower;
    public Transform shootpoint;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    public void Shoot()
    {
        GameObject newShell=Instantiate(shell, shootpoint.position, shootpoint.rotation) as GameObject;
        Rigidbody r = newShell.GetComponent<Rigidbody>();
        r.velocity = shootpoint.forward * shootPower;

        audioSource.Play();
    }

}
