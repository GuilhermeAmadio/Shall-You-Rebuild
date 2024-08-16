using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMode : MonoBehaviour
{
    public NavMeshAgent agent;
    public EnemyPatrol enemyPatrol;
    public FloatSO timer, enemyRange;
    public IntSO enemyDamage;
    public SoundSO hit;

    public SpawnSprite spawnSprite;

    public CharacterHealth charHealth;
    public FuncionCalled onCharDamaged;
    public VilaPerson vilaPerson;

    public enum Mode { Pursue, Patrol, Attack }

    public Mode mode = Mode.Patrol;

    public bool infinitePursue;

    private bool patrolling, attacking;
    private Vector3 placeToGoPatrol;
    private Transform playerTransform;
    private BoxCollider patrolArea;

    private List<EnemyAttackable> attackableList = new List<EnemyAttackable>();

    private void Start()
    {
        patrolArea = enemyPatrol.GetPatrolArea();

        mode = Mode.Patrol;
    }

    private void Update()
    {
        if (mode == Mode.Patrol)
        {
            if (!infinitePursue)
            {
                if (patrolling == false)
                {
                    NewArea();
                }
                else
                {
                    agent.SetDestination(placeToGoPatrol);

                    if (IsPathComplete())
                    {
                        patrolling = false;
                    }
                }
            }
        }
        else if (mode == Mode.Pursue)
        {
            agent.SetDestination(playerTransform.position);

            if (!infinitePursue)
            {
                if (!patrolArea.bounds.Contains(transform.position))
                {
                    mode = Mode.Patrol;
                }
            }
        }
    }

    private void NewArea()
    {
        float x = Random.Range(patrolArea.bounds.min.x, patrolArea.bounds.max.x);
        float z = Random.Range(patrolArea.bounds.min.z, patrolArea.bounds.max.z);
        placeToGoPatrol = new Vector3(x, 0f, z);

        patrolling = true;
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

    public void EnterAttackMode(EnemyAttackable enemyAttackable)
    {
        spawnSprite.ChangeSpriteAnimation("Work", true);
        attackableList.Add(enemyAttackable);

        if (!attacking)
        {
            mode = Mode.Attack;
            attacking = true;
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        while (attacking)
        {
            yield return new WaitForSeconds(timer.value);

            bool waitingForAttack = true;

            while (waitingForAttack)
            {
                if (attackableList.Count > 0)
                {
                    if (attackableList[attackableList.Count - 1] != null)
                    {
                        if (Vector3.Distance(attackableList[attackableList.Count - 1].transform.position, transform.position) <= enemyRange.value)
                        {
                            attackableList[attackableList.Count - 1].charHealth.TakeDamage(enemyDamage.value);
                            hit.Play();
                            waitingForAttack = false;
                        }
                        else
                        {
                            attackableList.Remove(attackableList[attackableList.Count - 1]);
                        }
                    }
                }
                else
                {
                    mode = Mode.Pursue;
                    attacking = false;
                    spawnSprite.ChangeSpriteAnimation("Work", false);
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTransform = other.transform;
            patrolling = false;

            mode = Mode.Pursue;
        }
    }

    private void CheckLife()
    {
        if (charHealth.GetCurrentHealth() <= 0)
        {
            if (vilaPerson != null)
            {
                vilaPerson.Taken();
            }
        }
    }

    private void OnEnable()
    {
        onCharDamaged.onFuncionCalled += CheckLife;
    }

    private void OnDisable()
    {
        onCharDamaged.onFuncionCalled -= CheckLife;
    }
}
