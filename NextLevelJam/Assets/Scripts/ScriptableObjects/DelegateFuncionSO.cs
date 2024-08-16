using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Delegate", menuName = "Stats/New Delegate")]
public class DelegateFuncionSO : ScriptableObject
{
    public delegate void OnFuncionCalled();
    public OnFuncionCalled onFuncionCalled;
}
