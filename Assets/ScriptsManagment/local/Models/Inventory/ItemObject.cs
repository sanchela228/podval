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
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Vector3 pos = new Vector3() { x = 0, z = -2, y = 0 };

            if (rayHit.transform != null && rayHit.collider.CompareTag("SlotForItem"))
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
                    if (!rayHitSlot.IsActive())
                    {
                        var targetObject = rayHitSlot.GetComponentInChildren<ItemObject>();

                        Debug.Log(targetObject);
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
            
        }

    }
}

