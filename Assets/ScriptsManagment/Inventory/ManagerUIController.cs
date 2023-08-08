using Models;
using DataBase;
using DataBase.XML;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUIController : MonoBehaviour
{
    private List<GameObject> ListUI = new List<GameObject>();

    void Start()
    {
        var Inventory = GameObject.Find("InventoryUI"); 
        var InterectiveUI = GameObject.Find("InterectiveUI");

        Controllers.InterfaceController.LoadUIItem(Inventory);
        Controllers.InterfaceController.LoadUIItem(InterectiveUI);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            GameObject inv =  Controllers.InterfaceController.ListUI.Find(b => b.name == "InventoryUI");
            Controllers.InterfaceController.ToggleUIActive(inv);
        }
    }
}
