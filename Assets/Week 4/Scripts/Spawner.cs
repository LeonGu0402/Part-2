using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject plane;
    public float timeValue;
    public float timeTarget;
    // Start is called before the first frame update
    void Start()
    {
        timeValue = 0f;
        timeTarget = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        timeValue = timeValue + 1f * Time.deltaTime;
        if (timeValue > timeTarget)
        {
            Instantiate(plane);
            timeTarget = Random.Range(1f, 5f);
            timeValue = 0f;
        }
    }
}
