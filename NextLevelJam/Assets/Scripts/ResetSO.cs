using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSO : MonoBehaviour
{
    public IntSO sOToReset;
    public int startValue;
    public DelegateFuncionSO delegateToReset;

    private void Start()
    {
        sOToReset.value = startValue;

        if (delegateToReset != null)
        {
            delegateToReset.onFuncionCalled.Invoke();
        }
    }
}
