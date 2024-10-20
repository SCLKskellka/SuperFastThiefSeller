using UnityEngine;
using UnityEngine.EventSystems;

namespace Christopher.Scripts
{
    public class DragableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
        private Transform _previousParent;
        private Canvas _canvas;
        private RectTransform _rectTransform;

        private void Awake() {
            _previousParent = transform.parent;
            _canvas = GameManager.Instance.tradingMenuUI.transform.GetComponent<Canvas>();
            _rectTransform = GetComponent<RectTransform>();
        }
    
        public void OnDrag(PointerEventData eventData) {
            Debug.Log("OnDrag");
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnBeginDrag(PointerEventData eventData) {
            Debug.Log("OnBeginDrag");
            _previousParent = gameObject.transform.parent;
            gameObject.transform.SetParent(_canvas.transform);
            TraddingItemUIManager.Instance.ActiveArea();
        }

        public void OnEndDrag(PointerEventData eventData) {
            if (eventData.pointerDrag.gameObject.CompareTag("Inventory")) {
                eventData.pointerDrag.gameObject.transform.GetComponent<Inventory>().
                    AddItem(_previousParent.GetComponent<ItemSlot>().ItemData);
                RemoveItem();
            }
            if (eventData.pointerDrag.gameObject.CompareTag("Chest")) {
                eventData.pointerDrag.gameObject.transform.GetComponent<Chest>().
                    AddItem(_previousParent.GetComponent<ItemSlot>().ItemData);
                RemoveItem();
            }
            if (eventData.pointerDrag.gameObject.CompareTag("Trader")) {
                GameManager.Instance.Player.transform.GetComponent<Player>().
                    IncrementScore(_previousParent.GetComponent<ItemSlot>().ItemData);
                RemoveItem();
            }
            gameObject.transform.SetParent(_previousParent);
            TraddingItemUIManager.Instance.UnactiveArea();
            Debug.Log("OnEndDrag");
        }

        private void RemoveItem() {
            if(_previousParent.parent.parent.name == "Panel")
                TraddingItemUIManager.Instance.chest.RemoveItem(_previousParent.GetComponent<ItemSlot>().ItemData);
            else TraddingItemUIManager.Instance.inventory.RemoveItem(_previousParent.GetComponent<ItemSlot>().ItemData);
        }
    }
}
