using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Resource
{
    public enum ResourceType { gold, wheat, wood, rock, iron, magicStone, farmer, lumberjack, miner, constructor, warrior, archer, mage }

    public ResourceType type;
}
