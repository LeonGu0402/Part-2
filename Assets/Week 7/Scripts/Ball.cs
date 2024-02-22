using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Collider2D goal;
    Rigidbody2D rb;
    public Transform reset;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == goal)
        {
            Controller.score += 1;
            rb.transform.position = reset.position;
            rb.velocity = new Vector2(0, 0);
        }
    }
}
