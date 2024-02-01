using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour
{
    public int score = 0;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (rb.OverlapPoint(collision.gameObject.transform.position))
        {
            
            Plane plane = collision.gameObject.GetComponent<Plane>();
            plane.land = true;
        }
        score = score + 1;
    }
}
