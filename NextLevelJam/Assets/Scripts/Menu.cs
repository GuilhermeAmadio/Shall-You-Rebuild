using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadGame()
    {
        LevelChanger.instance.ChangeLevel("Cutscene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
