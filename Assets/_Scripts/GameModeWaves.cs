using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeWaves : MonoBehaviour
{
    [SerializeField]
    private Life playerLife;

    [SerializeField]
    private Life baseLife;

    //PERDER
    private void Start()
    {
        playerLife.onDeath.AddListener(CheckLoseCondition);
        baseLife.onDeath.AddListener(CheckLoseCondition);

        EnemyManager.SharedInstance.onEnemyChanged.AddListener(CheckWinCondition);
        WaveManager.SharedInstance.onWaveChanged.AddListener(CheckWinCondition);
    }
    void CheckLoseCondition()
    {
        SceneManager.LoadScene("LoseScene", LoadSceneMode.Single);
    }

    void CheckWinCondition()
    {
        //GANAR
        if (WaveManager.SharedInstance.WavesCount <= 0 && EnemyManager.SharedInstance.EnemyCount <= 0)
        {
            RegisterScore();
            RegisterTime();
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        }
    }

    void RegisterScore()
    {
        var puntajeActual = ScoreManager.SharedInstance.Cantidad;
        PlayerPrefs.SetInt("Last Score", puntajeActual);

        var puntajeMaximo = PlayerPrefs.GetInt("Best Score", 0);

        if (puntajeActual > puntajeMaximo)
        {
            PlayerPrefs.SetInt("Best Score", puntajeActual);
        }
    }

    void RegisterTime()
    {
        var tiempoActual = Time.time;
        PlayerPrefs.SetFloat("Last Time", tiempoActual);

        var mejorTiempo = PlayerPrefs.GetFloat("Best Time", 999999.0f);

        if (tiempoActual < mejorTiempo)
        {
            PlayerPrefs.SetFloat("Best Time", tiempoActual);
        }
    }
}
