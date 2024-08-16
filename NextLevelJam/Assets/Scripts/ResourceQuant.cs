using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourceQuant
{
    public Resource resource;
    public IntSO quant;
    public DelegateFuncionSO onResourceQuantChanged;
    public bool consumable;

    public void ChangeQuant(int amount)
    {
        quant.value += amount;

        onResourceQuantChanged.onFuncionCalled.Invoke();
    }

    public int CheckQuant()
    {
        return quant.value;
    }
}
