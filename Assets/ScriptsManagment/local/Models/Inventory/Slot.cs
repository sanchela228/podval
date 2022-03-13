using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models.Inventory
{
    public class Slot : MonoBehaviour
    {
        public bool ActiveSlot;

        public TypesItem Type;
        public Item Item;

        protected SpriteRenderer _spriteSlot;

        private void Start()
        {
            _spriteSlot = GetComponent<SpriteRenderer>();
        }

        void OnGUI()
        {
            if (Item != null)
            {
                if (Item.Icon != null) _spriteSlot.sprite = Item.Icon;
            }

            
        }
    }
}

