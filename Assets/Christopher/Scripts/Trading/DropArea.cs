using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Christopher.Scripts {
    public class DropArea : MonoBehaviour, IDropHandler {
        private IDropHandler _dropHandlerImplementation;
        private Transform _previousParent;

        public void OnDrop(PointerEventData eventData) {
            Debug.Log("Item drop");
            if (gameObject.CompareTag("Inventory")) {
                TraddingItemUIManager.Instance.Inventory.AddItem(_previousParent.GetComponent<ItemSlot>().ItemData);/*<<mon problem*/
                RemoveItem();
                Debug.Log("Add Item in Inventory");
                return;
            }
            if (gameObject.CompareTag("Chest")) {
                eventData.pointerDrag.gameObject.transform.GetComponent<Chest>().
                    AddItem(_previousParent.GetComponent<ItemSlot>().ItemData);/*<<mon problem*/
                RemoveItem();
                Debug.Log("Add Item in chest");
                return;
            }
            if (gameObject.CompareTag("Trader")) {
                Debug.Log("Item sold?");
                GameManager.Instance.Player.transform.GetComponent<Player>()
                    .IncrementScore(_previousParent.GetComponent<ItemSlot>().ItemData);/*<<mon problem*/
                Debug.Log(GameManager.Instance.Player.transform.GetComponent<Player>().Score);
                RemoveItem();
                Debug.Log("Item sold");
                return;
            }
            gameObject.transform.SetParent(_previousParent);
            TraddingItemUIManager.Instance.UnactiveArea();
            Debug.Log("Item drop");
        }
        private void RemoveItem() {
            if(_previousParent.parent.parent.name == "Panel")
                TraddingItemUIManager.Instance.Chest.RemoveItem(_previousParent.GetComponent<ItemSlot>().ItemData);
            else TraddingItemUIManager.Instance.Inventory.RemoveItem(_previousParent.GetComponent<ItemSlot>().ItemData);
        }
    }
}
