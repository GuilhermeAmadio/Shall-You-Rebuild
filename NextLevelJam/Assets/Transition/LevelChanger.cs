using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public static LevelChanger instance;

    private string levelToLoad;

    private Animator anim;

    private void Awake()
    {
        instance = this;

        anim = GetComponent<Animator>();
    }

    public void ChangeLevel(string level)
    {
        anim.SetTrigger("FadeOut");

        levelToLoad = level;
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
