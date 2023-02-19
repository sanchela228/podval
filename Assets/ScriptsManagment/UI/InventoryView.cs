using DataBase;
using DataBase.XML;
using Models;
using Models.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    public GameObject Head;
    public GameObject Body;

    public ItemsDataBase ItemsDataBase;

    private XMLManager XMLUser = new XMLManager("user");
    private List<Item> AllItemsList;

    void Start()
    {
        AllItemsList = ItemsDataBase.listItem;

        //LoadTargetItems();
    }

    private void LoadTargetItems()
    {
        List<GameObject> targetGameObjects = new List<GameObject>() { Head, Body };

        foreach (GameObject target in targetGameObjects)
        {
            ItemObject currentSlot = target.GetComponent<ItemObject>();

            string idCurrentSlotXML = XMLUser.GetProperty(Utils.CamelCaseToLowerString(currentSlot.name));
            Item saveItem = AllItemsList.Find(b => b.Id == idCurrentSlotXML);

            if(saveItem != null) currentSlot.Item = saveItem;
        }
    }
}
