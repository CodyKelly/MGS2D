using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour 
{
    public float attackCooldown = 0f;
    public AudioSource audioSource;
    public AudioClip audioClip;

    protected float lastAttackTime;

    void Start()
    {
        lastAttackTime = Time.time - attackCooldown;    // Make sure weapon can be used at start of game
    }

    void FixedUpdate()
    {
        foreach (Transform t in transform.parent)
        {
            t.position = transform.parent.position;
        }
        if (Input.GetMouseButton(0) && Time.time - attackCooldown > lastAttackTime)
        {
            Attack();
        }
    }

    public abstract void Attack();
}
