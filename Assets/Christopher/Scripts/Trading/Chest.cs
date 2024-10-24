using System;
using UnityEngine;

namespace Christopher.Scripts {
    public class Chest : MonoBehaviour {
        [SerializeField] private GameObject[] slotLineList;
        private ItemToSell _currentItemData;
        private void OnEnable() {
            UpgradeItemsValue();
        }

        public bool HaveFreeSlot() {
            for (int i = 0; i < slotLineList.Length; i++) {
                for (int j = 0; j < slotLineList[i].transform.GetComponent<SlotsLine>().Slots.Length; j++) {
                    if (slotLineList[i].transform.GetComponent<SlotsLine>().Slots[j].GetComponent<ItemSlot>().ItemData 
                        == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void AddItem(ItemToSell itemData) {
            for (int i = 0; i < slotLineList.Length; i++) {
                for (int j = 0; j < slotLineList[i].transform.GetComponent<SlotsLine>().Slots.Length; j++) {
                    _currentItemData = slotLineList[i].transform.GetComponent<SlotsLine>().Slots[j]
                        .GetComponent<ItemSlot>().ItemData;
                    if (_currentItemData == null)
                    {
                        _currentItemData = itemData;
                        return;
                    }
                }
            }
        }
        public void RemoveItem(ItemToSell itemData) {
            for (int i = 0; i < slotLineList.Length; i++) {
                for (int j = 0; j < slotLineList[i].transform.GetComponent<SlotsLine>().Slots.Length; j++) {
                    if (slotLineList[i].transform.GetComponent<SlotsLine>().Slots[j].GetComponent<ItemSlot>().ItemData 
                        == itemData)
                    {
                        slotLineList[i].transform.GetComponent<SlotsLine>().Slots[j].GetComponent<ItemSlot>().ItemData =
                            null;
                        return;
                    }
                }
            }
        }

        private void UpgradeItemsValue() {
            for (int i = 0; i < slotLineList.Length; i++) {
                for (int j = 0; j < slotLineList[i].transform.GetComponent<SlotsLine>().Slots.Length; j++) {
                    _currentItemData = slotLineList[i].transform.GetComponent<SlotsLine>().Slots[j]
                        .GetComponent<ItemSlot>().ItemData;
                    if ( _currentItemData != null) {
                        _currentItemData.CurrentValue += _currentItemData.BasicValue;
                        return;
                    }
                }
            }
        }
    }
}
