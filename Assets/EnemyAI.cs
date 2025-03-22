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
    public float attackRange = 1f;
    public float detectionRange = 5f;   
    public int damageAmount = 1;

    public Transform[] patrolPoints;
    public LayerMask playerLayer;

    private Transform player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool movingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
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

    private void Patrol()
    {
        if (patrolPoints.Length > 0)
        {
            if (transform.position.x < patrolPoints[0].position.x)
            {
                movingRight = true;
                sr.flipX = false;
            }
            else if (transform.position.x > patrolPoints[1].position.x)
            {
                movingRight = false;
                sr.flipX = true;
            }

            if (movingRight)
            {
                rb.velocity = new Vector2(patrolSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-patrolSpeed, rb.velocity.y);
            }

            if (Vector2.Distance(transform.position, player.position) < detectionRange)
            {
                currentState = EnemyState.Chase;
            }
        }
    }

    private void Chase()
    {
        if (transform.position.x < player.position.x)
        {
            movingRight = true;
            sr.flipX = false;
        }
        else
        {
            movingRight = false;
            sr.flipX = true;
        }

        if (movingRight)
        {
            rb.velocity = new Vector2(chaseSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-chaseSpeed, rb.velocity.y);
        }

        if (Vector2.Distance(transform.position, player.position) < attackRange)
        {
            currentState = EnemyState.Attack;
        }
        else if (Vector2.Distance(transform.position, player.position) > detectionRange)
        {
            currentState = EnemyState.Patrol;
        }
    }

    private void Attack()
    {
        return;
    }


}

