using Controllers;
using UnityEngine;

namespace Models.Inventory
{
    public class Slot : MonoBehaviour
    {
        public bool ActiveItem;
        public TypesItem Type;

        private Color DefaultColor;
        private bool isHighlighted;
        RaycastHit2D rayHit;

        public Item ItemObject;


        public bool IsActive()
        {
            return ActiveItem;
        }

        void Start()
        {
            DefaultColor = transform.GetComponent<UnityEngine.UI.Image>().color;

        }

        void Update()
        {

            // this code create background color if slot have item

            /* rayHit = Physics2D.Raycast(transform.position, Vector2.one);

            if (rayHit.collider.CompareTag("Item"))
            {
                this.isHighlighted = true;
            }
            else this.isHighlighted = false;

            if (this.isHighlighted) transform.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            else transform.GetComponent<UnityEngine.UI.Image>().color = DefaultColor;*/
        }

        public void removeItemFromSlot(Item Item)
        {
            ItemObject = null;

            if (this.GetSyncInterface())
            {
                this.GetSyncInterface().mapObject.Environment.Change<Item>( Item, "remove");
            }
        }

        public void addItemFromSlot(Item Item)
        {
            ItemObject = Item;

            if (this.GetSyncInterface())
            {
                this.GetSyncInterface().mapObject.Environment.Change<Item>( Item, "add");
            }
        }

        public SyncInterfaceWithMapObject GetSyncInterface()
        {
            return this.transform.GetComponentInParent<Controllers.SyncInterfaceWithMapObject>();
        }

        public bool IsEmpty()
        {
            return transform.childCount == 0;
        }
    }
}

