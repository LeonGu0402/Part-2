using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    public GameObject player;
    Vector2 direction;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

    }

    private void FixedUpdate()
    {
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rb.rotation = -angle + 180;
    }

    // Update is called once per frame
    void Update()
    {
        direction = transform.position - player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("damage", SendMessageOptions.DontRequireReceiver);
    }
}
