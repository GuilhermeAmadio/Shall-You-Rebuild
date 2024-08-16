using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Healable"))
        {
            other.gameObject.GetComponentInChildren<ChangingHealthWithScript>().ResetHealthBar();
        }
    }
}
