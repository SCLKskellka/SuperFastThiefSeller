using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Christopher.Scripts {
    public class TraddingItemUIManager : MonoBehaviourSingleton<TraddingItemUIManager> {
        //public GameObject Inventory;
        //public GameObject Chest;
        //public GameObject Trader;
        [Header("TraddingScripts")] 
        public Inventory Inventory;
        public Chest Chest;
        [Header("DropArea")]
        public GameObject InventoryDropArea;
        public GameObject ChestDropArea;
        public GameObject TraderDropArea; 
        [Header("TradingCanvas")]
        [SerializeField] private GameObject tradingMenuUI;

        private void Awake() {
            InventoryDropArea.SetActive(false);
            ChestDropArea.SetActive(false);
            TraderDropArea.SetActive(false);
        }

        public void ActiveArea() {
            InventoryDropArea.SetActive(true);
            if (Chest.HaveFreeSlot())ChestDropArea.SetActive(true);
            else ChestDropArea.SetActive(false);
            TraderDropArea.SetActive(true);
        }
        public void UnactiveArea() {
            InventoryDropArea.SetActive(false);
            ChestDropArea.SetActive(false);
            TraderDropArea.SetActive(false);
        }
    }
}
