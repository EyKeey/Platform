using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyState
    {
        Patrol,
        Chase,
        Attack
    }
    public EnemyState currentState = EnemyState.Patrol;

    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float attackRange = 0f;
    public float detectionRange = 0f;   
    public int damageAmount = 1;

    public Transform[] patrolPoints;
    public LayerMask playerLayer;

    private Transform player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool movingRight = true;
    private int currentPatrolPointIndex = 0; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        CheckState();

        switch(currentState)
        {
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
        }
    }
    
    public void CheckState()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
    
        if(distanceToPlayer <= attackRange)
        {
            currentState = EnemyState.Attack;
        }
        else if (distanceToPlayer <= detectionRange)
        {
            currentState = EnemyState.Chase;
        }
        else
        {
            currentState = EnemyState.Patrol;
        }
    }

    public void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        Transform target = patrolPoints[currentPatrolPointIndex];
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = new Vector2 (direction.x * patrolSpeed, rb.velocity.y);
        
        if(Vector2.Distance(transform.position, target.position) <= 0.3f)
        {
            currentPatrolPointIndex = (currentPatrolPointIndex + 1) % patrolPoints.Length;
        }

        FlipSprite(direction.x);
    }

    private void FlipSprite(float direction)
    {
        if(direction > 0 && !movingRight)
        {
            movingRight = true;
            sr.flipX = false;
        }
        else if (direction < 0 && movingRight)
        {
            movingRight = false;
            sr.flipX = true;
        }
    }

    public void Chase()
    {

    }

    public void Attack()
    {

    }

}

