using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleUI : MonoBehaviour
{
    public IntSO peopleCount;
    public DelegateFuncionSO peopleChanged;
    public IntSO farmerCount, lumberjackCount, minerCount, constructorCount, warriorCount, archerCount, mageCount;
    public DelegateFuncionSO farmerChanged, lumberjackChanged, minerChanged, constructorChanged, warriorChanged, archerChanged, mageChanged;

    private void UpdatePeopleCount()
    {
        peopleCount.value = farmerCount.value + lumberjackCount.value + minerCount.value + constructorCount.value + warriorCount.value + archerCount.value + mageCount.value;

        peopleChanged.onFuncionCalled.Invoke();
    }

    private void OnEnable()
    {
        farmerChanged.onFuncionCalled += UpdatePeopleCount;
        lumberjackChanged.onFuncionCalled += UpdatePeopleCount;
        minerChanged.onFuncionCalled += UpdatePeopleCount;
        constructorChanged.onFuncionCalled += UpdatePeopleCount;
        warriorChanged.onFuncionCalled += UpdatePeopleCount;
        archerChanged.onFuncionCalled += UpdatePeopleCount;
        mageChanged.onFuncionCalled += UpdatePeopleCount;
    }

    private void OnDisable()
    {
        farmerChanged.onFuncionCalled -= UpdatePeopleCount;
        lumberjackChanged.onFuncionCalled -= UpdatePeopleCount;
        minerChanged.onFuncionCalled -= UpdatePeopleCount;
        constructorChanged.onFuncionCalled -= UpdatePeopleCount;
        warriorChanged.onFuncionCalled -= UpdatePeopleCount;
        archerChanged.onFuncionCalled -= UpdatePeopleCount;
        mageChanged.onFuncionCalled -= UpdatePeopleCount;
    }
}
