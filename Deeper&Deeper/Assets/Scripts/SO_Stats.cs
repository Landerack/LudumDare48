using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Statblock_", menuName = "ScriptableObjects/SO_Stats", order = 1)]
public class SO_Stats : ScriptableObject
{
    public float maxHealth;
    public float movementspeed;

    public bool canFly;
}
