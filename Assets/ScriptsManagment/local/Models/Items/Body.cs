using UnityEngine;

namespace Models.Items
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Assets/Items/Body")]
    public class Body : Item
    {
        public int Health;
        public int Armor;
    }
}