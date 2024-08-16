using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comerciante : MonoBehaviour, Interactable
{
    public RequiredResource[] neededResources;
    public RequiredResource resourceToGain;

    public SoundSO interactSound;

    public GameObject showRequired;

    private bool haveAllResources;

    public void Interact(PlayerWork playerWork)
    {
        haveAllResources = true;

        for (int i = 0; i < neededResources.Length; i++)
        {
            ResourceQuant resource = ResourcesManager.Instance.GetResource(neededResources[i].resource);

            for (int j = 0; j < neededResources[i].requiredQuant; j++)
            {
                if (resource.CheckQuant() <= 0)
                {
                    haveAllResources = false;
                    break;
                }
            }
        }

        if (haveAllResources)
        {
            ResourceQuant resource = ResourcesManager.Instance.GetResource(resourceToGain.resource);
            resource.ChangeQuant(resourceToGain.requiredQuant);

            for (int i = 0; i < neededResources.Length; i++)
            {
                ResourceQuant resource2 = ResourcesManager.Instance.GetResource(neededResources[i].resource);

                for (int j = 0; j < neededResources[i].requiredQuant; j++)
                {
                    resource2.ChangeQuant(-1);
                }
            }

            interactSound.Play();
        }
    }

    public void SecondaryInteraction()
    {
        Debug.Log("Não tem");
    }

    public void ShowRequired(bool check)
    {
        showRequired.SetActive(check);
    }
}
