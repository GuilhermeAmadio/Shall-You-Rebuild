using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionInteract : MonoBehaviour, Interactable
{
    public RequiredResource[] requiredResources;

    public GameObject constructionToBuild;
    public GameObject parentObj, showRequired;
    public SoundSO sound;

    private bool haveAllResources;

    public void Interact(PlayerWork playerWork)
    {
        haveAllResources = true;

        for (int i = 0; i < requiredResources.Length; i++)
        {
            ResourceQuant resource = ResourcesManager.Instance.GetResource(requiredResources[i].resource);

            for (int j = 0; j < requiredResources[i].requiredQuant; j++)
            {
                if (resource.CheckQuant() <= 0 || resource.CheckQuant() < requiredResources[i].requiredQuant)
                {
                    haveAllResources = false;
                    break;
                }
            }
        }

        if (haveAllResources)
        {
            Instantiate(constructionToBuild, transform.position, parentObj.transform.rotation);
            sound.Play();

            for (int i = 0; i < requiredResources.Length; i++)
            {
                ResourceQuant resource = ResourcesManager.Instance.GetResource(requiredResources[i].resource);

                for (int j = 0; j < requiredResources[i].requiredQuant; j++)
                {
                    if (resource.consumable)
                    {
                        resource.ChangeQuant(-1);
                    }
                }
            }

            Destroy(parentObj);
        }
    }

    public void SecondaryInteraction()
    {
        Debug.Log("Isso não é possível cancelar!");
    }

    public void ShowRequired(bool check)
    {
        if (showRequired != null)
            showRequired.SetActive(check);
    }
}
