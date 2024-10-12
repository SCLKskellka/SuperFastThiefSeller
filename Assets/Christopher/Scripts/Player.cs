using System;
using System.Collections.Generic;
using UnityEngine;

namespace Christopher.Scripts
{
    public class Player : MonoBehaviour {
        public List<ItemToSell> Inventory;
        public ItemToSell[] Chest;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.transform.CompareTag("Item")) {
                Inventory.Add(other.transform.GetComponent<Item>().MyCurrentItemData);
                other.gameObject.SetActive(false);
            }
            if (other.transform.CompareTag("Exit")) {
                //timescale 0 + reste gameposition to begin
                //open stocking and selling menu
            }
        }
    }
}