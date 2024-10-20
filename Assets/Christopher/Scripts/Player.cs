using System;
using System.Collections.Generic;
using UnityEngine;

namespace Christopher.Scripts
{
    public class Player : MonoBehaviour {
        public List<ItemToSell> Inventory;
        public List<ItemToSell> Chest;
        public int Score;

        public void ResetPlayer() {
            Inventory.Clear();
            Chest.Clear();
            Score = 0;
        }

        public void IncrementScore(ItemToSell item) {
            Score += item.CurrentValue;
        }
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.transform.CompareTag("Item")) {
                Inventory.Add(other.transform.GetComponent<Item>().MyCurrentItemData);
                other.gameObject.SetActive(false);
                Debug.Log("nombre d'objet ramassé:"+Inventory.Count);
            }
            if (other.transform.CompareTag("Exit")) {
                GameManager.Instance.TradingSequence();
            }
        }
    }
}