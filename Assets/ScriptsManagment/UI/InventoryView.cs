using DataBase.XML;
using Models;
using Models.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] Inventory TargetInventory;
    [SerializeField] RectTransform ItemsPanel;

    public GameObject Head;
    public GameObject Body;

    public ItemsDataBase ItemsDataBase;

    void Start()
    {
        XMLManager XMLUser = new XMLManager("user");

        Slot slotHead = Head.GetComponent<Slot>();
        string slotHeadName = Utils.CamelCaseToLowerString(slotHead.name);

        string idHeadXML = XMLUser.GetProperty(slotHeadName);

        var test = ItemsDataBase.listItem;
        var test2 = test.Find(b => b.Id == idHeadXML);

        slotHead.Item = test2;

        //slotHead.Item = idHeadXML;


    }

}
