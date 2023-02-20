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

        ListUI.Add(Inventory);
        ListUI.Add(InterectiveUI);

        Inventory.SetActive(false);
        //InterectiveUI.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I)) VisibleUI("InventoryUI");

        if (Input.GetKeyUp(KeyCode.L)) Test();
    }

    public void Test()
    {
        
    }

    public void VisibleUI(string Name)
    {
        var UI = ListUI.Find(b => b.name == Name);

        if (UI.activeSelf) UI.SetActive(false);
        else UI.SetActive(true);
    }
}
