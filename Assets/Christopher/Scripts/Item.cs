using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

namespace Christopher.Scripts
{
    public class Item : MonoBehaviour {
        public ItemToSell MyCurrentItemData { get; private set; }
        private Helper.Rarity _myCurrentItemRarity;
        

        private void OnEnable() {
            RaritySelect();
            ItemSelect();
        }
        private void RaritySelect() {
            System.Random dice = new Random();
            int diceValue = dice.Next(1, 100);
            if (diceValue > 98) _myCurrentItemRarity = Helper.Rarity.mythic;
            else if (diceValue > 90) _myCurrentItemRarity = Helper.Rarity.epic;
            else if (diceValue > 75) _myCurrentItemRarity = Helper.Rarity.rare;
            else if (diceValue > 40) _myCurrentItemRarity = Helper.Rarity.uncomon;
            else _myCurrentItemRarity = Helper.Rarity.comon;
        }
        private void ItemSelect() {
            switch (_myCurrentItemRarity) {
                case Helper.Rarity.mythic:
                    MyCurrentItemData = Helper.SelectRandomIndexInArray(ItemEncyclopedia.Instance.AllMythicItem);
                    transform.GetComponent<SpriteRenderer>().color = ItemEncyclopedia.Instance.MythicColor;
                    break;
                case Helper.Rarity.epic:
                    MyCurrentItemData = Helper.SelectRandomIndexInArray(ItemEncyclopedia.Instance.AllEpicItem);
                    transform.GetComponent<SpriteRenderer>().color = ItemEncyclopedia.Instance.EpicColor;
                    break;
                case Helper.Rarity.rare:
                    MyCurrentItemData = Helper.SelectRandomIndexInArray(ItemEncyclopedia.Instance.AllRareItem);
                    transform.GetComponent<SpriteRenderer>().color = ItemEncyclopedia.Instance.RareColor;
                    break;
                case Helper.Rarity.uncomon:
                    MyCurrentItemData = Helper.SelectRandomIndexInArray(ItemEncyclopedia.Instance.AllUncomonItem);
                    transform.GetComponent<SpriteRenderer>().color = ItemEncyclopedia.Instance.UncomonColor;
                    break;
                case Helper.Rarity.comon:
                    MyCurrentItemData = Helper.SelectRandomIndexInArray(ItemEncyclopedia.Instance.AllComonItem);
                    transform.GetComponent<SpriteRenderer>().color = ItemEncyclopedia.Instance.ComonColor;
                    break;
            }
        }
    }
}