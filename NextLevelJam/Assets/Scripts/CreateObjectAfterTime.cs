using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectAfterTime : MonoBehaviour
{
    public GameObject obj;
    public float timer;
    public string scene;

    private void Awake()
    {
        StartCoroutine(CreateObjAfterTimer());
    }

    private IEnumerator CreateObjAfterTimer()
    {
        yield return new WaitForSeconds(timer);

        Create();
    }

    public void Create()
    {
        GameObject obje = Instantiate(obj);

        LevelChanger.instance.ChangeLevel(scene);
    }
}
