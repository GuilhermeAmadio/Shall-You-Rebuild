using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonWork : MonoBehaviour
{
    public Resource resource;
    public IntSO resourceCount;
    public DelegateFuncionSO resourceChanged;
    public Person person;
    public PersonInteract personInteract;
    public SpawnSprite spawnSprite;
    public NavMeshAgent agent;
    public SoundSO houseSound;

    private IWorkable workable;
    private Transform workPos, restPos;
    private bool work, startWork, rest;

    private void Update()
    {
        if (work)
        {
            agent.SetDestination(workPos.position);

            if (IsPathComplete())
            {
                spawnSprite.ChangeSpriteAnimation("Work", true);

                if (!startWork)
                {
                    workable.StartWork();

                    startWork = true;
                }
            }
        }
        else if (rest)
        {
            agent.SetDestination(restPos.position);

            if (IsPathComplete())
            {
                houseSound.Play();
                person.DisableSprite();
            }
        }
    }

    private bool IsPathComplete()
    {
        if (Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                return true;
            }
        }

        return false;
    }

    public void Work(Transform workPos, IWorkable workable)
    {
        person.FollowPlayer(false);

        this.workPos = workPos;
        this.workable = workable;

        work = true;
    }

    public void Rest(Transform restPos)
    {
        person.FollowPlayer(false);
        resourceCount.value--;
        resourceChanged.onFuncionCalled.Invoke();

        this.restPos = restPos;

        rest = true;
    }

    public void StopWorking()
    {
        person.FollowPlayer(true);

        spawnSprite.ChangeSpriteAnimation("Work", false);

        workPos = null;

        work = false;
        startWork = false;
    }

    public void StopResting()
    {
        person.FollowPlayer(true);
        personInteract.AddWorker();
        resourceCount.value++;
        resourceChanged.onFuncionCalled.Invoke();
        houseSound.Play();

        restPos = null;

        rest = false;

        person.EnableSprite();
    }
 
    public bool IsWorking()
    {
        return work;
    }
}
