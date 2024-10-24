using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Christopher.Scripts {
   public class ItemSlot : MonoBehaviour {
      public ItemToSell ItemData = null;
      public GameObject MyChild;

      private void Awake() {
         MyChild = transform.GetChild(0).gameObject;
      }
      private void Update() {
         if (ItemData != null && MyChild.transform.GetComponent<Image>().sprite != ItemData.MyIcon){
            MyChild.transform.GetComponent<Image>().sprite = ItemData.MyIcon;
            MyChild.SetActive(true);
         }
         if (ItemData == null && MyChild.transform.GetComponent<Image>().sprite != null) {
            MyChild.transform.GetComponent<Image>().sprite = null;
            MyChild.SetActive(false);
         }
      }
   }
}
