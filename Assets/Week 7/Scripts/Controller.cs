using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    float chargeValue;
    public float maxCharge = 1;
    Vector2 direction;

    public static float score = 0;
    public TMP_Text scoreUI;

    public static PlayerSelection SelectedPlayer {  get; private set; }

    public static void setSelectedPlayer(PlayerSelection player)
    {
        if (SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);
        }
        SelectedPlayer = player;
        SelectedPlayer.Selected(true);
    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            SelectedPlayer.Move(direction);
            direction = Vector2.zero;
            chargeValue = 0;
            chargeSlider.value = 0;
        }
    }

    private void Update()
    {
        if (SelectedPlayer == null) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            chargeValue = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            chargeValue += Time.deltaTime;
            chargeValue = Mathf.Clamp(chargeValue, 0, maxCharge);
            chargeSlider.value = chargeValue;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)SelectedPlayer.transform.position).normalized * chargeValue;
        }
        scoreUI.text = score.ToString();
    }
}
