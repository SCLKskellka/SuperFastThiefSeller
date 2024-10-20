using UnityEngine;
using Color = System.Drawing.Color;

[CreateAssetMenu(menuName = "Create ItemToSell", fileName = "ItemToSell", order = 0)]
public class ItemToSell : ScriptableObject {
    public Sprite MyIcon;
    public Helper.Rarity MyRarity;
    public int BasicValue;
    public int CurrentValue;
}