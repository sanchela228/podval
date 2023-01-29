using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Models.Inventory
{
    public class Slot : MonoBehaviour
    {
        public bool ActiveSlot;

        public TypesItem Type;
        public Item Item;
        public Sprite SpriteDefault;

        protected Image image;
     

        private void Start()
        {
            image = GetComponent<Image>();
        }

        void OnGUI()
        {
            if (Item != null && Item.Icon != SpriteDefault)
            {
                if (Item.Icon != null) image.sprite = Item.Icon;
            }
            else
            {
                image.sprite = SpriteDefault;
            }

            
        }
    }
}

