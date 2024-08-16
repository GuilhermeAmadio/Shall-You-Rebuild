using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private CharacterHealth charHealth;

    public void UpdateHealthBar(int currentValue)
    {
        healthSlider.value = currentValue;

        if (currentValue >= healthSlider.maxValue)
        {
            healthSlider.gameObject.SetActive(false);
        }
        else
        {
            healthSlider.gameObject.SetActive(true);
        }
    }

    public void ResetHealthBar(int maxValue)
    {
        healthSlider.maxValue = maxValue;
        charHealth.ResetLife();

        UpdateHealthBar(maxValue);
    }
}
