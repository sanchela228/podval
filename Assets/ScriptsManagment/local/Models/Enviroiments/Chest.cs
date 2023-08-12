using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Models.Environments
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Assets/Environments/Chest")]
    public class Chest : Environment
    {
        public GameObject Interface;

        public List<Models.Item> Items;

        public override void Click(MapObject _mapObject)
        {
            var _interface = Controllers.InterfaceController.ToggleInteractiveUI(Interface);
            _interface.GetComponent<Controllers.SyncInterfaceWithMapObject>().mapObject = _mapObject;

            if (Items.Count > 0 && _interface != null) 
                Controllers.InterfaceController.PutItemsInInterface(_interface, Items);
        }
    }
}