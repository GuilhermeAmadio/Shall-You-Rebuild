using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeOnSpawn : MonoBehaviour
{
    public DelegateFuncionSO onDragonDeath;

    private void Start()
    {
        onDragonDeath.onFuncionCalled.Invoke();
    }
}
