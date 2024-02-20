using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void playScene()
    {
        SceneManager.LoadScene(1);
    }

    public void gameOver()
    {
        SceneManager.LoadScene(2);
    }
}
