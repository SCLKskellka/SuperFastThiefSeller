using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Christopher.Scripts
{
    public class DragableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {
        public Transform PreviousParent;
        private Image _image;
        private Canvas _canvas;
        private RectTransform _rectTransform;
        private int _currentDragSelect;

        private void Awake() {
            _image = GetComponent<Image>();
            PreviousParent = transform.parent;
            _canvas = GameManager.Instance.tradingMenuUI.transform.GetComponent<Canvas>();
            _rectTransform = GetComponent<RectTransform>();
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            _currentDragSelect = 0;
            if (eventData.pointerDrag.gameObject.CompareTag("Inventory"))
            {
                _currentDragSelect = 1;
                Debug.Log("Add Item in Inventory?" + _currentDragSelect);
            }
            Debug.Log("OnDrag");
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void OnBeginDrag(PointerEventData eventData) {
            Debug.Log("OnBeginDrag");
            PreviousParent = gameObject.transform.parent;
            gameObject.transform.SetParent(_canvas.transform);
            _image.raycastTarget = false;
            TraddingItemUIManager.Instance.ActiveArea();
        }

        public void OnEndDrag(PointerEventData eventData) {
            _image.raycastTarget = true;
            Debug.Log("OnEndDrag");
        }

       
    }
}
