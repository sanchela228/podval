using Controllers;
using Models.Environments;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

namespace Models.Inventory
{
    public class ItemObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        Vector3 _diference;

        Transform _transform;
        Transform defaultParent;

        RaycastHit2D rayHit;

        public Item Item;

        protected UnityEngine.UI.Image image;

        private Camera mainCamera;
        private Sprite SpriteDefault;

        private void Start()
        {
            mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            image = GetComponent<UnityEngine.UI.Image>();
            _transform = GetComponent<Transform>();
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

        private void Update()
        {
            _diference = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _diference.z = -2;

            rayHit = Physics2D.Raycast(_diference, Vector2.zero);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _transform.position = _diference;
            defaultParent = _transform.parent;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _transform.position = _diference;

            if (rayHit.transform != null)
            {
                Debug.Log(rayHit.collider.name);
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Vector3 pos = new Vector3() { x = 0, z = -2, y = 0 };

            if (rayHit.transform != null && rayHit.collider.CompareTag("SlotForItem"))
            {
                if (defaultParent == rayHit.transform) _transform.SetParent(defaultParent);
                else
                {
                    Slot rayHitSlot = rayHit.transform.GetComponent<Slot>();

                    if (rayHitSlot.IsEmpty())
                    {
                        if (rayHitSlot.IsActive())
                        {
                            if (Item._isUserProperty)
                            {
                                if (rayHitSlot.Type == Item.Type) this.swapParentSlotOnEndDrag(rayHitSlot, defaultParent.GetComponent<Slot>());
                                else _transform.SetParent(defaultParent);
                            }
                            else _transform.SetParent(defaultParent);

                        }
                        else
                        {
                            this.swapParentSlotOnEndDrag(rayHitSlot, defaultParent.GetComponent<Slot>());
                        }
                    }
                    else
                    {
                        if (!rayHitSlot.IsActive() && !defaultParent.GetComponent<Slot>().IsActive())
                        {
                            var targetObject = rayHitSlot.GetComponentInChildren<ItemObject>();

                            targetObject.transform.SetParent(defaultParent);
                            targetObject.transform.localPosition = pos;

                            this.justSwapWithOutInterface(rayHitSlot, defaultParent.GetComponent<Slot>(), targetObject);

                            _transform.SetParent(rayHit.transform);
                        }
                        else
                        {
                            /// poka default potom swap if type ==
                            _transform.SetParent(defaultParent);
                        }
                    }
                }
            }
            else if (rayHit.transform != null && rayHit.collider.name == "backMaskUI")
            {
                GameObject drop = (GameObject) Collector.Get("MapObject", _diference);
                Drop envir = (Drop) Collector.Get("b30ea009-c3f3-4c32-86d6-bbe7a2525beb");
                envir.Items.Add(Item);

                drop.GetComponent<MapObject>().Environment = envir;
                defaultParent.GetComponent<Slot>().removeItemFromSlot(Item);
                
                if (defaultParent.GetComponent<Slot>().transform.childCount > 0)
                    UnityEngine.Object.Destroy(defaultParent.GetComponent<Slot>().transform.GetChild(0).gameObject);

               // defaultParent.GetComponentInParent<SyncInterfaceWithMapObject>().mapObject.Environment
               // if ()
            }
            else
            {
                _transform.SetParent(defaultParent);
            }

            _transform.localPosition = pos;
        }

        protected void justSwapWithOutInterface(Slot newSlot, Slot oldSlot, ItemObject nonTargetItem)
        {
            var item = nonTargetItem.Item;

            newSlot.removeItemFromSlot(item);
            oldSlot.removeItemFromSlot(Item);

            oldSlot.addItemFromSlot(item);
            newSlot.addItemFromSlot(Item);
        }

        protected void swapParentSlotOnEndDrag(Slot newSlot, Slot oldSlot)
        {
            _transform.SetParent(rayHit.transform);

            if (newSlot.GetSyncInterface() != oldSlot.GetSyncInterface())
            {
                newSlot.addItemFromSlot(Item);
                oldSlot.removeItemFromSlot(Item);
            }

            if (!newSlot.GetSyncInterface() && !oldSlot.GetSyncInterface())
            {
                newSlot.addItemFromSlot(Item);
                oldSlot.removeItemFromSlot(Item);
            }
            
        }

    }
}

