using UnityEngine;
using Color = System.Drawing.Color;

namespace Christopher.Scripts
{
    public class ItemEncyclopedia : MonoBehaviourSingleton<ItemEncyclopedia> {
        public ItemToSell[] AllComonItem;
        public ItemToSell[] AllUncomonItem;
        public ItemToSell[] AllRareItem;
        public ItemToSell[] AllEpicItem;
        public ItemToSell[] AllMythicItem;
        public Color32 ComonColor;
        public Color32 UncomonColor;
        public Color32 RareColor;
        public Color32 EpicColor;
        public Color32 MythicColor;
    }
}
