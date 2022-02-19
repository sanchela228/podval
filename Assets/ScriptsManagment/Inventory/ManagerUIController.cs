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
        ListUI.Add(Inventory);

        Inventory.SetActive(false);
    }

    void Update()
    {
        var Manager = new XMLManager();

        if (Input.GetKeyUp(KeyCode.I)) VisibleUI("InventoryUI");

        if (Input.GetKeyUp(KeyCode.L)) Manager.Save();
    }

    public void VisibleUI(string Name)
    {
        var UI = ListUI.Find(b => b.name == Name);
        var status = UI.activeSelf;

        if (status) UI.SetActive(false);
        else UI.SetActive(true);
    }
}
