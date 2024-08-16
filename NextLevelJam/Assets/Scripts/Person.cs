using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour
{
    private Transform player;
    public Rigidbody rb;
    public NavMeshAgent agent;
    public SpawnSprite spawnSprite;

    private bool followPlayer;

    private void Start()
    {
        EnableSprite();
    }

    void Update()
    {
        if (followPlayer)
        {
            agent.SetDestination(player.position);

            if (!IsPathComplete())
            {
                spawnSprite.ChangeAnimAnimation("Move", true);
            }
            else
            {
                spawnSprite.ChangeAnimAnimation("Move", false);
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

    public void SetPlayerPos(Transform player)
    {
        this.player = player;
    }

    public void FollowPlayer(bool follow)
    {
        followPlayer = follow;
    }

    public void EnableSprite()
    {
        spawnSprite.enabled = true;
    }

    public void DisableSprite()
    {
        spawnSprite.enabled = false;
    }
}
