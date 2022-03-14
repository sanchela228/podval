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
        public Sprite SpriteDefault;

        protected SpriteRenderer spriteSlot;
     

        private void Start()
        {
            spriteSlot = GetComponent<SpriteRenderer>();
        }

        void OnGUI()
        {
            if (Item != null && Item.Icon != SpriteDefault)
            {
                if (Item.Icon != null) spriteSlot.sprite = Item.Icon;
            }
            else
            {
                spriteSlot.sprite = SpriteDefault;
            }

            
        }
    }
}

