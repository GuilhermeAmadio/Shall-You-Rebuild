using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseInteract : MonoBehaviour, Interactable
{
    public Resource[] residentResources;

    public IntSO peopleAmount, maxPeople;
    public DelegateFuncionSO peopleChanged;

    public Transform restPos;
    public GameObject show;

    private List<PersonWork> workers = new List<PersonWork>();

    public void Interact(PlayerWork playerWork)
    {
        for (int i = 0; i < residentResources.Length; i++)
        {
            PersonWork worker = playerWork.RestWorker(residentResources[i], restPos);

            if (worker != null)
            {
                workers.Add(worker);

                break;
            }
        }
    }

    public void SecondaryInteraction()
    {
        StopRest();
    }

    public void ShowRequired(bool check)
    {
        show.SetActive(check);
    }

    public void StopRest()
    {
        if (workers.Count > 0)
        {
            if (peopleAmount.value < maxPeople.value)
            {
                workers[0].StopResting();
                workers.RemoveAt(0);
            }
        }
    }
}
