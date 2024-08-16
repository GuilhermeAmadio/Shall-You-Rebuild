using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyMode enemyMode;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyAttackable>() != null)
        {
            EnemyAttackable enemyAttackable = other.gameObject.GetComponent<EnemyAttackable>();
            enemyMode.EnterAttackMode(enemyAttackable);
        }
    }
}
