using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float turnSpeed = 5f;
    public Transform target;
    public float chaseRange = 10f;

    public bool isProvoked = false;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    Animator animator;
    EnemyHealth health;

    public AudioClip provokedAudio;
    public bool alreadyPlayed = false;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        health = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (health.isDead == true)
        {
            this.enabled = false; // Here we are saying to disabe this whole script/component/class.
            navMeshAgent.enabled = false;
            Invoke("DisableAnimator", 1.5f);
            audioSource.enabled = false;
        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);               
        if (distanceToTarget <= chaseRange) { isProvoked = true; }

        if (isProvoked == true)
        {
            EngageTarget();
            if(!alreadyPlayed)
            {
                audioSource.PlayOneShot(provokedAudio, 8f);
                alreadyPlayed = true;
            }
        }

        if (isProvoked == false) { return; }
    }

    private void DisableAnimator()
    {
        animator.enabled = false;
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            //transform.LookAt(target);
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        animator.SetBool("Attack", false);
        animator.SetTrigger("Move");
        navMeshAgent.SetDestination(target.position);
    }

    public void AttackTarget()
    {
        animator.SetBool("Attack", true);
        //transform.LookAt(target);
        //print(gameObject.name + "Attacking" + target.name);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        //transform.rotation = lookRotation;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}