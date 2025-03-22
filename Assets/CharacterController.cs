using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 7.0f;
    public LayerMask groundLayer;

    [HideInInspector] public bool isGrounded = true;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (InputManager.instance == null)
        {
            Debug.LogError("InputManager instance is null");
            return;
        }

        if (InputManager.instance.isAttacking)
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        CheckGround();


        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
         
        int horizontalInput = InputManager.instance.horizontalInput;
        int verticalInput = InputManager.instance.verticalInput;

        Vector2 velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = velocity;

        float rotation = horizontalInput >= 0 ? 0 : 180;
        transform.localRotation = Quaternion.Euler(0, rotation, 0);

        animator.SetInteger("horizontalInput", Mathf.Abs(horizontalInput));

        if (verticalInput > 0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else
        {
            return;
        }
    }

    private void HandleRotation()
    {
        return;
    }

    private void Attack()
    {
        Debug.Log("Attacking");
        return;
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * 1.5f);
    }
}
