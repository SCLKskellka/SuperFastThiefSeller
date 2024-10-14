using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
   [SerializeField] private GameObject objectToSpawn;
    private float _maxValue = 10;
    private float _minValue = 2;
    private float _currentValue;
    private bool _isStarted;

    private void Awake() {
       _minValue = ItemManager.Instance.minValue;
       _maxValue = ItemManager.Instance.maxValue;
    }

    private void Start() {
      if(objectToSpawn.activeSelf == false)objectToSpawn.SetActive(true);
   }

   private void Update() {
      if (objectToSpawn.activeSelf == false && _isStarted == false) {
         Random random = new Random();
         _currentValue = random.Next((int)_minValue, (int)_maxValue);
         _isStarted = true;
      }
      if (_currentValue > 0) {
         _currentValue -= Time.deltaTime;
      } 
      if(_currentValue <= 0 && _isStarted){
         objectToSpawn.SetActive(true);
         _isStarted = false;
      }
   }
}
