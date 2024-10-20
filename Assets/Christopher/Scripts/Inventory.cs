using System;
using System.Collections.Generic;
using UnityEngine;

namespace Christopher.Scripts {
    public class Inventory : MonoBehaviour {
        
        [SerializeField] private GameObject slotListPanel;
        
        private List<ItemToSell> _playerInventory ;
        private List<GameObject> _slotLineList = new List<GameObject>();

        private void Awake() {
            _playerInventory = GameManager.Instance.Player.transform.GetComponent<Player>().Inventory;;
        }

        void Start() {
            UpdateListSlotLine();
        }

        private void OnEnable() {
            UpdateListSlotLine();
            InitiateInventory();
        }
    
        public void ResetInventory() {
            for (int i = 0; i < _slotLineList.Count; i++) {
                for (int j = 0; j < _slotLineList[i].transform.GetComponent<SlotsLine>().Slots.Length; j++) {
                    if (_slotLineList[i].transform.GetComponent<SlotsLine>().Slots[j].GetComponent<ItemSlot>().ItemData 
                        != null)
                    {
                        _slotLineList[i].transform.GetComponent<SlotsLine>().Slots[j].GetComponent<ItemSlot>().ItemData =
                            null;
                    }
                }
            }
        }
    
        public void InitiateInventory() {
            InitiateSlotLine(_playerInventory.Count / 5 +1);
            InitiateSlots();
        }
        private void InitiateSlotLine(int numberOfLine) {
            for (int i = 0; i < _slotLineList.Count; i++) {
                if (i >= numberOfLine) _slotLineList[i].SetActive(false);
                else _slotLineList[i].SetActive(true);
            }
        }
        private void InitiateSlots() {
            foreach (ItemToSell itemData in _playerInventory) {
                AddItem(itemData);
            }
        }

        private void UpdateListSlotLine() {
            for (int i = 0; i < slotListPanel.transform.childCount; i++) {
                _slotLineList.Add(slotListPanel.transform.GetChild(i).gameObject);
            }
        }

        public void AddItem(ItemToSell itemData) {
            for (int i = 0; i < _slotLineList.Count; i++) {
                for (int j = 0; j < _slotLineList[i].transform.GetComponent<SlotsLine>().Slots.Length; j++) {
                    if (_slotLineList[i].transform.GetComponent<SlotsLine>().Slots[j].GetComponent<ItemSlot>().ItemData 
                        == null)
                    {
                        _slotLineList[i].transform.GetComponent<SlotsLine>().Slots[j].GetComponent<ItemSlot>().ItemData =
                            itemData;
                        return;
                    }
                }
            }
        }
        public void RemoveItem(ItemToSell itemData) {
            for (int i = 0; i < _slotLineList.Count; i++) {
                for (int j = 0; j < _slotLineList[i].transform.GetComponent<SlotsLine>().Slots.Length; j++) {
                    if (_slotLineList[i].transform.GetComponent<SlotsLine>().Slots[j].GetComponent<ItemSlot>().ItemData 
                        == itemData)
                    {
                        _slotLineList[i].transform.GetComponent<SlotsLine>().Slots[j].GetComponent<ItemSlot>().ItemData =
                            null;
                        return;
                    }
                }
            }
        }
    }
}
