using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    public Text actualScore, actualTime, bestScore, bestTime;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        actualScore.text = "Puntaje: " + PlayerPrefs.GetInt("Last Score");
        actualTime.text = "Tiempo: " + PlayerPrefs.GetFloat("Last Time");
        bestScore.text = "Mejor Puntaje: " + PlayerPrefs.GetInt("Best Score");
        bestTime.text = "Mejor Tiempo " + PlayerPrefs.GetFloat("Best Time");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Level 1");
    }
}
