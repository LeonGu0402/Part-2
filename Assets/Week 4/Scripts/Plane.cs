using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Rigidbody2D rb;
    Vector2 currentPosition;
    public float speed = 1f;
    public AnimationCurve landing;
    float timerValue;
    public List<Sprite> planeSprites;
    SpriteRenderer sprtiteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprtiteRenderer = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        speed = Random.Range(1, 3);
        sprtiteRenderer.sprite = planeSprites[Random.Range(0, planeSprites.Count)];


        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = - angle;
        }
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            timerValue += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(timerValue);
            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0)
        {
            if (Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(lastPosition, newPosition) > newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }
    }
}
