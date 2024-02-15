using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public Transform startPosition;
    public Transform endPosition;
    public float lerpTimer = 0;
    SpriteRenderer sr;
    public Color startColor;
    public Color endColor;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = animationCurve.Evaluate(lerpTimer);
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, interpolation);
        lerpTimer += Time.deltaTime;

        if (lerpTimer > 1)
        {
            lerpTimer = 0;
        }

        sr.color = Color.Lerp(startColor, endColor, interpolation);
    }
}
