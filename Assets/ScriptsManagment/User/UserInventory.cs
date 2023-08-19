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
    public List<Item> InventoryItems = new List<Item>();

    public GameObject HeadSlot;
    public Head Head;

    public GameObject BodySlot;
    public Body Body;





    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( HeadSlot.transform.childCount > 0 )
            Head = (Head) HeadSlot.GetComponentInChildren<ItemObject>().Item;

        if (BodySlot.transform.childCount > 0)
            Body = (Body) BodySlot.GetComponentInChildren<ItemObject>().Item;


    }
}