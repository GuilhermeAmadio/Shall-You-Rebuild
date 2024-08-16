using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleUpgrades : MonoBehaviour
{
    public CastleSO castle;
    public IntSO maxPeople, castleLevel, maxFarmer, maxLamberjack, maxMiner, maxConstructor, maxWarrior, maxArcher, maxMage;
    public DelegateFuncionSO changePeople, changeFarmer, changeLamberjack, changeMiner, changeConstructor,
        changeWarrior, changeArcher, changeMage;

    private void Start()
    {
        maxPeople.value = castle.newMaxPeople;
        castleLevel.value = castle.newCastleLevel;
        maxFarmer.value = castle.newMaxFarmer;
        maxLamberjack.value = castle.newMaxLumberjack;
        maxMiner.value = castle.newMaxMiner;
        maxConstructor.value = castle.newMaxConstructor;
        maxWarrior.value = castle.newMaxWarrior;
        maxArcher.value = castle.newMaxArcher;
        maxMage.value = castle.newMaxMage;

        changePeople.onFuncionCalled.Invoke();
        changeFarmer.onFuncionCalled.Invoke();
        changeLamberjack.onFuncionCalled.Invoke();
        changeMiner.onFuncionCalled.Invoke();
        changeConstructor.onFuncionCalled.Invoke();
        changeWarrior.onFuncionCalled.Invoke();
        changeArcher.onFuncionCalled.Invoke();
        changeMage.onFuncionCalled.Invoke();
    }
}
