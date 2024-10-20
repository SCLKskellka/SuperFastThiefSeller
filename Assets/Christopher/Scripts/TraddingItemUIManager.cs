using System;
using UnityEngine;

namespace Christopher.Scripts {
    public class TraddingItemUIManager : MonoBehaviourSingleton<TraddingItemUIManager> {
        //public GameObject Inventory;
        //public GameObject Chest;
        //public GameObject Trader;
        [Header("TraddingScripts")] 
        public Inventory inventory;
        public Chest chest;
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
            if (chest.HaveFreeSlot())ChestDropArea.SetActive(true);
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
