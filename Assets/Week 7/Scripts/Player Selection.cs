using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSelection : MonoBehaviour
{

    public Color selectColour;
    public Color unselectColour;
    SpriteRenderer sr;
    Rigidbody2D rb;
    public float speed = 500f;


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Selected(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            sr.color = selectColour;
        }
        else if (!isSelected)
        {
            sr.color=unselectColour;
        }
    }

    private void OnMouseDown()
    {
        Controller.setSelectedPlayer(this);
    }

    public void Move(Vector2 direction)
    {
        rb.AddForce(direction * speed);
    }
}
