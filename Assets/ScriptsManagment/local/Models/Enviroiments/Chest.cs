using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Models.Environments
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Assets/Environments/Chest")]
    public class Chest : Environment
    {
        public GameObject Interface;
        public List<Models.Item> Items;

        public override void Change<Item>(Item _item, string parameters = null)
        {
            Models.Item item = _item as Models.Item;

            if (parameters == "remove")
                Items.Remove( Items.Single(a => a.Id == item.Id) );
            
            if (parameters == "add") Items.Add(item);
        }

        public override void Click(MapObject _mapObject)
        {
            float dist = Vector3.Distance(_mapObject.transform.position, GameObject.Find("MainPlayer").transform.position);

            if (dist <= 60)
            {
                var _interface = Controllers.InterfaceController.ToggleInteractiveUI(Interface);

                if (_interface != null)
                    _interface.GetComponent<Controllers.SyncInterfaceWithMapObject>().mapObject = _mapObject;

                if (Items.Count > 0 && _interface != null)
                    Controllers.InterfaceController.PutItemsInInterface(_interface, Items);
            }
        }

        public override void UpdatePerFrame(MapObject _mapObject, string v = null)
        {
            float dist = Vector3.Distance(_mapObject.transform.position, GameObject.Find("MainPlayer").transform.position);

            if (dist > 60 && Controllers.InterfaceController.ListUI.Find(b => b.name == "InterectiveUI")) 
                Controllers.InterfaceController.CloseInteractiveInterface();
        }
    }
}  