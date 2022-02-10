using UnityEngine;

namespace Models.Items
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Assets/Items/Head")]
    public class Head : Item
    {
        public int Health;
        public int Armor;
    }
}