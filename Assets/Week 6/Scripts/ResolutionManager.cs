using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{

    public void Set16_9()
    {
        Screen.SetResolution(1600, 900, true);
    }

    public void SetFullHD()
    {
        Screen.SetResolution(1920, 1080, true);
    }
}
