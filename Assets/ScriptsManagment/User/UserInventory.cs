using Controllers;
using Models;
using Models.Inventory;
using Models.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[SerializeField]
public class UserInventory : MonoBehaviour
{
    public GameObject Grid;
    public Item[] Items;

    public GameObject HeadSlot;
    public Head Head;

    public GameObject BodySlot;
    public Body Body;


    void Start()
    {
        Items = new Item[Grid.transform.childCount];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        { 
            InterfaceController.CloseAllInterfaces();
        }

        for (int i = 0; i < Grid.transform.childCount; i++)
        {
            Item item = Grid.transform.GetChild(i).GetComponent<Slot>().ItemObject;

            if (item != null) Items[i] = item;
            else Items[i] = null;   
        }


        if ( HeadSlot.transform.childCount > 0 )
            Head = (Head) HeadSlot.GetComponentInChildren<ItemObject>().Item;
        else Head = null;

        if (BodySlot.transform.childCount > 0)
            Body = (Body) BodySlot.GetComponentInChildren<ItemObject>().Item;
        else Body = null;


    }
}