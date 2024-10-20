using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotsLine : MonoBehaviour {
    public GameObject[] Slots = new GameObject[5];
    void Awake() {
        for (int i = 0; i < Slots.Length; i++) {
            Slots[i] = transform.GetChild(i).gameObject;
        }
    }
}
