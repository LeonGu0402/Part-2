using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    public Rigidbody2D goalKeeper;
    public float distance;
    Vector2 direction;
    Vector2 playerPosition;
    Vector2 goalLinePosition;
    public float goalRadius = 2;
    public float speed = 1;

    private void FixedUpdate()
    {
        if (Controller.SelectedPlayer == null) return;

        if (distance < goalRadius)
        {
            goalKeeper.position = Vector2.MoveTowards(goalKeeper.position, goalLinePosition - direction * distance, speed);
        }
        else if (distance > goalRadius)
        {
            goalKeeper.position = Vector2.MoveTowards(goalKeeper.position, goalLinePosition - direction * goalRadius, speed);
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (Controller.SelectedPlayer == null) return;
        playerPosition = (Vector2)Controller.SelectedPlayer.transform.position;
        goalLinePosition = (Vector2)transform.position;

        direction = goalLinePosition - playerPosition;
        distance = direction.magnitude / 2;
        direction.Normalize();


        
    }
}
