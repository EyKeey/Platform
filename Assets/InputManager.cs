using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [HideInInspector] public int horizontalInput = 0;
    [HideInInspector] public int verticalInput = 0;
    [HideInInspector] public bool isAttacking = false;
    
    private bool isTouchingLeft = false;
    private bool isTouchingRight = false;
    private Vector2 leftTouchStartPos;
    private Vector2 RightTouchStartPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        isAttacking = false;

        foreach (var touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                HandleLeftTouch(touch);
            }
            else
            {
                HandleRightTouch(touch);
            }
        }

        
    }

    public void HandleLeftTouch(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            leftTouchStartPos = touch.position;
            isTouchingLeft = true;
        }
        else if (touch.phase == TouchPhase.Moved && isTouchingLeft)
        {
            float deltaX = touch.position.x - leftTouchStartPos.x;

            if (MathF.Abs(deltaX) > 20)
            {
                if (deltaX > 0)
                {
                    horizontalInput = 1;
                }
                else if (deltaX < 0)
                {
                    horizontalInput = -1;
                }
                else
                {
                    horizontalInput = 0;
                }
            }
        }
        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            isTouchingLeft = false;
            horizontalInput = 0;
        }
    }
    
    public void HandleRightTouch(Touch touch)
    {

        if (touch.phase == TouchPhase.Began)
        {
            RightTouchStartPos = touch.position;
            isTouchingRight = true;
        }
        else if (touch.phase == TouchPhase.Moved && isTouchingRight)
        {
            float deltaY = touch.position.y - RightTouchStartPos.y;

            if (MathF.Abs(deltaY) > 20)
            {
                if (deltaY > 0)
                {
                    verticalInput = 1;
                }
                else if (deltaY < 0)
                {
                    verticalInput = -1;
                }
                else
                {
                    verticalInput = 0;
                }
            }
            
        }
        else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            if (Mathf.Abs(touch.position.y - RightTouchStartPos.y) < 20)
            {
            
                isAttacking = true;
            }
            isTouchingRight = false;
            verticalInput = 0;
        }
    }
}
