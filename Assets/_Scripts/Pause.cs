using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    public Button exitButton;

    public AudioMixerSnapshot pauseSNP, gameSNP;

    private void Awake()
    {
        pauseMenu.SetActive(false);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;

            pauseSNP.TransitionTo(0.01f);
        }
    }
    public void ResumeGame()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);

        gameSNP.TransitionTo(0.2f);
    }

    private void ExitGame()
    {
        print("Ejecución Finalizada");
        Application.Quit();
    }
}
