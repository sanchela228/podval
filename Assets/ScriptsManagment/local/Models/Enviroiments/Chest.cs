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
            var _interface = Controllers.InterfaceController.ToggleInteractiveUI(Interface);

            if (_interface != null)
                _interface.GetComponent<Controllers.SyncInterfaceWithMapObject>().mapObject = _mapObject;

            if (Items.Count > 0 && _interface != null) 
                Controllers.InterfaceController.PutItemsInInterface(_interface, Items);
        }
    }
}