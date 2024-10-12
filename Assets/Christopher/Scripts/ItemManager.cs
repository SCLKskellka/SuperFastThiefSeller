using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviourSingleton<ItemManager> {
    [Header("Timer Settings")]
    public float maxValue = 10;
    public float minValue = 2;
}
