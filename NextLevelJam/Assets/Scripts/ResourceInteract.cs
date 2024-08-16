using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInteract : MonoBehaviour, Interactable, IWorkable
{
    public RequiredResource[] workResources;
    public Resource resourceToGain;

    public IntSO resourcesAvailableMax;
    public FloatSO timer, timerToRespawn;
    public SoundSO interactSound;

    private int resourcesAvailable;
    private bool haveAllResources, collecting, isFull = true;

    public GameObject full, empty, showRequired;
    private List<PersonWork> workers = new List<PersonWork>();

    private void Start()
    {
        resourcesAvailable = resourcesAvailableMax.value;
    }

    public void Interact(PlayerWork playerWork)
    {
        if (!collecting && isFull)
        {
            haveAllResources = true;

            for (int i = 0; i < workResources.Length; i++)
            {
                ResourceQuant resource = ResourcesManager.Instance.GetResource(workResources[i].resource);

                for (int j = 0; j < workResources[i].requiredQuant; j++)
                {
                    if (resource.CheckQuant() <= 0 || resource.CheckQuant() < workResources[i].requiredQuant)
                    {
                        haveAllResources = false;
                        break;
                    }
                }
            }

            bool returnSomething = false;

            if (haveAllResources)
            {
                for (int i = 0; i < workResources.Length; i++)
                {
                    for (int j = 0; j < workResources[i].requiredQuant; j++)
                    {
                        returnSomething = playerWork.UseAllWorkersOfType(workResources[j].resource, transform, this);
                    }
                }

                if (returnSomething)
                {
                    collecting = true;
                }
            }
        }
    }

    private IEnumerator Collect()
    {
        bool canCollect = true;

        while (canCollect)
        {
            yield return new WaitForSeconds(timer.value);

            ResourceQuant resource = ResourcesManager.Instance.GetResource(resourceToGain);
            resource.ChangeQuant(workers.Count);

            resourcesAvailable -= workers.Count;
            interactSound.Play();

            if (resourcesAvailable <= 0)
            {
                Empty();
                StartCoroutine(WaitToRespawn());

                StopWork();
                canCollect = false;
            }
        }
    }

    private void Empty()
    {
        isFull = false;
        collecting = false;
        showRequired.SetActive(false);

        full.SetActive(false);
        empty.SetActive(true);
    }

    private void Full() 
    { 
        isFull = true;
        resourcesAvailable = resourcesAvailableMax.value;

        full.SetActive(true);
        empty.SetActive(false);
    }

    private IEnumerator WaitToRespawn()
    {
        yield return new WaitForSeconds(timerToRespawn.value);

        Full();
    }

    public void StartWork()
    {
        StartCoroutine(Collect());
    }

    private void Cancel()
    {
        if (collecting)
        {
            StopWork();
            StopAllCoroutines();

            collecting = false;
        }
    }

    public void StopWork()
    {
        foreach (PersonWork worker in workers)
        {
            worker.StopWorking();
        }

        workers.Clear();
    }

    public void AddWorker(PersonWork worker)
    {
        workers.Add(worker);
    }

    public void RemoveWorker(PersonWork worker)
    {
        workers.Remove(worker);
    }

    public void SecondaryInteraction()
    {
        Cancel();
    }

    public void ShowRequired(bool check)
    {
        if (isFull)
        {
            showRequired.SetActive(check);
        }
    }
}
