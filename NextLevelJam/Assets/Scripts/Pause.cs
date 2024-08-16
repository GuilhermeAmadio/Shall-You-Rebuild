using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool paused;

    public GameObject UI, pauseObj, gameOver, win, helpObj;

    public DelegateFuncionSO onPlayerDeath, onDragonDeath;

    public void PauseGame()
    {
        if (!paused)
        {
            paused = true;
            UI.SetActive(false);
            pauseObj.SetActive(true);

            Time.timeScale = 0f;
        }
        else
        {
            paused = false;
            UI.SetActive(true);
            pauseObj.SetActive(false);

            Time.timeScale = 1f;
        }
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        LevelChanger.instance.ChangeLevel("Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Help()
    {
        if (helpObj.activeSelf)
        {
            helpObj.SetActive(false);
        }
        else
        {
            helpObj.SetActive(true);
        }
    }

    private void Win()
    {
        Time.timeScale = 0f;
        win.SetActive(true);
        UI.SetActive(false);
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        UI.SetActive(false);
    }

    private void OnEnable()
    {
        onPlayerDeath.onFuncionCalled += GameOver;
        onDragonDeath.onFuncionCalled += Win;
    }

    private void OnDisable()
    {
        onPlayerDeath.onFuncionCalled -= GameOver;
        onDragonDeath.onFuncionCalled -= Win;
    }
}
