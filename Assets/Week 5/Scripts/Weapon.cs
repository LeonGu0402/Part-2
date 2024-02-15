using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 move = new Vector2(1, 0);
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + 1f * Time.deltaTime;
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knight")
        {
            collision.gameObject.SendMessage("TakeDamage", 1);
            Destroy(gameObject);
        }

    }


}
