using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonInteract : MonoBehaviour, Interactable
{
    public RequiredResource[] neededResources;
    public Person person;
    public PersonWork personWork;
    public IntSO quantPeople, maxPeople, requiredCastleLevel, castleLevel, quantResource, maxResource;

    public VilaPerson vilaPerson;
    public Resource resourceToGain;
    public BoxCollider coll;

    public SoundSO grunido;
    public GameObject showRequired;

    private bool interacted, haveAllResources;
    private PlayerWork player;

    public void Interact(PlayerWork playerWork)
    {
        if (!interacted)
        {
            if (requiredCastleLevel.value <= castleLevel.value)
            {
                if (quantPeople.value < maxPeople.value)
                {
                    if (quantResource.value < maxResource.value)
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
                            ResourceQuant resource = ResourcesManager.Instance.GetResource(resourceToGain);
                            resource.ChangeQuant(1);

                            for (int i = 0; i < neededResources.Length; i++)
                            {
                                ResourceQuant resource2 = ResourcesManager.Instance.GetResource(neededResources[i].resource);

                                for (int j = 0; j < neededResources[i].requiredQuant; j++)
                                {
                                    resource2.ChangeQuant(-1);
                                }
                            }

                            person.SetPlayerPos(playerWork.GetComponentInParent<Transform>());
                            person.FollowPlayer(true);

                            player = playerWork;
                            AddWorker();

                            interacted = true;
                            grunido.Play();

                            coll.enabled = false;
                            vilaPerson.Taken();
                            ShowRequired(false);
                            gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }

    public void AddWorker()
    {
        player.AddWorker(personWork);
    }

    public void SecondaryInteraction()
    {
        Debug.Log("Não é possível cancelar!");
    }

    public void ShowRequired(bool check)
    {
        showRequired.SetActive(check);
    }
}
