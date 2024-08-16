using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilaInteract : MonoBehaviour
{
    public GameObject person;
    public Transform spawnPos;

    public FloatSO timeToSpawn;

    private VilaPerson vilaPerson;

    private void Start()
    {
        SpawnPerson();
    }

    private void SpawnPerson()
    {
        GameObject personObj = Instantiate(person, spawnPos.position, Quaternion.identity);
        vilaPerson = personObj.GetComponent<VilaPerson>();

        vilaPerson.vila = this;
    }

    public void PersonTaken()
    {
        vilaPerson = null;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeToSpawn.value);

        SpawnPerson();
    }
}
