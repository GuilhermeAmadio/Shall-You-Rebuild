using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingHealthWithScript : MonoBehaviour
{
    public CharacterHealth charHealth;

    public HealthBar healthBar;

    public FuncionCalled onCharDamaged;

    private void Awake()
    {
        ResetHealthBar();
    }

    private void ChangeHealthBar()
    {
        healthBar.UpdateHealthBar(charHealth.GetCurrentHealth());
    }

    public void ResetHealthBar()
    {
        healthBar.ResetHealthBar(charHealth.GetMaxHealth());
    }

    private void OnEnable()
    {
        onCharDamaged.onFuncionCalled += ChangeHealthBar;
    }

    private void OnDisable()
    {
        onCharDamaged.onFuncionCalled -= ChangeHealthBar;
    }
}
