using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Castle", menuName = "Stats/New Castle")]
public class CastleSO : ScriptableObject
{
    public int newCastleLevel, newMaxPeople, newMaxFarmer, newMaxLumberjack, newMaxMiner, newMaxConstructor, newMaxWarrior, newMaxArcher, newMaxMage;
}
