using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    Vector2 mouse;
    Vector2 move;
    Vector2 originPoint;
    Animator animator;
    Rigidbody2D rb;
    public AnimationCurve animationCurve;
    public float lerpTime = 0;
    public float speed;
    public float fastSpeed = 6;
    public float slowSpeed = 2;
    Boolean left;
    Boolean right;

    public int health;
    public int appleNum;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = rb.GetComponent<Animator>();
        health = 5;
        appleNum = 0;
    }

    private void FixedUpdate()
    {
        move = mouse - rb.position;
        if (Vector2.Distance(mouse, transform.position) < 0.2)
        {
            move = new Vector2(0, 0);
            lerpTime = 0;
            animationReset();
        }

        rb.MovePosition(rb.position + move.normalized * speed * Time.deltaTime);
    }



    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            originPoint = rb.position;
            lerpTime = 0;
            animationReset();
        }

        speedLerp();

        if (speed > 3)
        {
            animationDetection();
        }
    }

    void speedLerp()
    {
        float interpolation = animationCurve.Evaluate(lerpTime);
        speed = Mathf.Lerp(fastSpeed, slowSpeed, interpolation);
        lerpTime += 0.5f * Time.deltaTime;
    }

    void animationDetection()
    {

        //determain the mouse is on left or right first
        if (mouse.x > originPoint.x)
        {
            right = true;
        }
        else if(mouse.x < originPoint.x)
        {
            left = true;
        }

        float gradient = (mouse.y - originPoint.y) / (mouse.x - originPoint.x);

        //determian base on its gridient
        if (right && gradient > 2)
        {
            animator.SetBool("up", true);
        }
        else if (right && gradient < -2)
        {
            animator.SetBool("down", true);
        }
        else if (right && gradient < 2 || right && gradient > -2)
        {
            animator.SetBool("right", true);
        }

        if (left && gradient < -2)
        {
            animator.SetBool("up", true);
        }
        else if(left && gradient > 2)
        {
            animator.SetBool("down", true);
        }
        else if (left && gradient > -2 || left && gradient < 2)
        {
            animator.SetBool("left", true);
        }


    }

    void animationReset()
    {
        animator.SetBool("up", false);
        animator.SetBool("left", false);
        animator.SetBool("right", false);
        animator.SetBool("down", false);
        right = false;
        left = false;
    }

    void appleGetOne()
    {
        appleNum += 1;
    }

    void damage()
    {
        health -= 1;
    }
}
