using System.Collections;
using System.Collections.Generic;
using Christopher.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;

abstract class ItemSlot : MonoBehaviour {
   public Player player;

   public void OnDrop(PointerEventData eventData)
   {
      Debug.Log("Dropped");
   }
}
