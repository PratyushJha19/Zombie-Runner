using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float hitpoints = 15f;
    Animator animator;
    public bool isDead = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        GetComponent<EnemyAI>().isProvoked = true;
        BroadcastMessage("OnDamageTaken");
        hitpoints = hitpoints - damage;
        if (hitpoints <= 0)
        {
            //isDead = true;
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        if (isDead == true)
        {
            animator.SetTrigger("Die And Fall");
        }
    }
}