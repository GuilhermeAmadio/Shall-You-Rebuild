using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject patrolAreaPrefab;
    private BoxCollider patrolArea;

    private void Awake()
    {
        GameObject patrolAreaObj = Instantiate(patrolAreaPrefab, transform.position, Quaternion.identity);
        patrolArea = patrolAreaObj.GetComponent<BoxCollider>();
    }

    public BoxCollider GetPatrolArea()
    {
        return patrolArea;
    }
}
