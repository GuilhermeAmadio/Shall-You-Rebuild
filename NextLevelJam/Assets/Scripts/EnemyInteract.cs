using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : MonoBehaviour, Interactable, IWorkable
{
    public Resource[] attackResources;
    public Resource resourceToGain;
    public IntSO dropGold;
    public FloatSO timer;

    public CharacterHealth charHealth;

    public GameObject show;

    private List<PersonWork> workers = new List<PersonWork>();

    private bool fighting;

    public void Interact(PlayerWork playerWork)
    {
        if (!fighting)
        {
            for (int i = 0; i < attackResources.Length; i++)
            {
                playerWork.UseAllWorkersOfType(attackResources[i], transform, this);
            }

            fighting = true;
        }
    }

    private IEnumerator Attack()
    {
        bool canAttack = true;

        while (canAttack)
        {
            yield return new WaitForSeconds(timer.value);

            int damageToTake = 0;
            foreach (var worker in workers)
            {
                if (worker != null)
                {
                    CharacterDamage characterDamage = worker.GetComponent<CharacterDamage>();
                    damageToTake += characterDamage.GetDamage();
                }
            }

            charHealth.TakeDamage(damageToTake);

            if (charHealth.GetCurrentHealth() <= 0)
            {
                //destroy

                StopWork();
                canAttack = false;

                ResourceQuant resource = ResourcesManager.Instance.GetResource(resourceToGain);
                resource.ChangeQuant(dropGold.value);
            }
        }
    }

    public void StartWork()
    {
        StartCoroutine(Attack());
    }

    public void StopWork()
    {
        foreach (PersonWork worker in workers)
        {
            if (worker != null)
            {
                worker.StopWorking();
            }
        }

        workers.Clear();
    }

    private void Cancel()
    {
        if (fighting)
        {
            StopWork();
            StopAllCoroutines();

            fighting = false;
        }
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
        show.SetActive(check);
    }
}
