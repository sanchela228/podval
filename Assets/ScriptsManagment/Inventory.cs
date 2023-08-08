using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public List<Item> InventoryItems = new List<Item>();

	public Item Helmet;
	public Item LeftHand;
	public Item RightHand;

	// test update github


	void Awake()
	{
		
	}

    public void AddItem(Item item)
	{
		InventoryItems.Add(item);
	}
}
