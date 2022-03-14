using DataBase;
using DataBase.XML;
using Models;
using Models.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        List<Item> _AllItemList = ItemsDataBase.listItem; // Поправить обработку на класс Base
        AllItemsList = _AllItemList;


        LoadTargetItems();
    }

    private void LoadTargetItems()
    {
        List<GameObject> targetGameObjects = new List<GameObject>() { Head, Body };

        foreach (GameObject target in targetGameObjects)
        {
            Slot currentSlot = target.GetComponent<Slot>();

            string idCurrentSlotXML = XMLUser.GetProperty(Utils.CamelCaseToLowerString(currentSlot.name));
            Item saveItem = AllItemsList.Find(b => b.Id == idCurrentSlotXML);

            currentSlot.Item = saveItem;
        }
    }
}
