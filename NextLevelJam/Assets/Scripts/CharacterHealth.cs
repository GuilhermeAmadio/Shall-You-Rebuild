using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public IntSO charHealth;
    public FuncionCalled onCharDamaged;
    public DelegateFuncionSO onCharDeath;
    public SoundSO deathSound;

    public int currentHealth;

    public GameObject parentObj;

    private void OnEnable()
    {
        ResetLife();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (onCharDamaged != null)
        {
            onCharDamaged.onFuncionCalled.Invoke();
        }

        if (currentHealth < 0)
        {
            deathSound.Play();

            if (onCharDeath != null)
            {
                onCharDeath.onFuncionCalled.Invoke();
            }

            Destroy(parentObj);
        }
    }

    public void ResetLife()
    {
        currentHealth = charHealth.value;
    }

    public int GetMaxHealth()
    {
        return charHealth.value;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
