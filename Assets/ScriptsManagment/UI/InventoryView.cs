using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] Inventory TargetInventory;
    [SerializeField] RectTransform ItemsPanel;

    // named object items in inventory equals name TargetInventory slots
    // private string[] NamesFixedSlotsInventory = { "Helmet", "RightHand" , "LeftHand" };


    void Start()
    {

        if (TargetInventory.Helmet != null)
		{
            var helmet = transform.Find("Helmet");
            helmet.GetComponent<SpriteRenderer>().sprite = TargetInventory.Helmet.Icon;
        }

        if (TargetInventory.RightHand != null)
        {
            var righthand = transform.Find("RightHand");
            righthand.GetComponent<SpriteRenderer>().sprite = TargetInventory.RightHand.Icon;
        }

        if (TargetInventory.LeftHand != null)
        {
            var lefthand = transform.Find("LeftHand");
            lefthand.GetComponent<SpriteRenderer>().sprite = TargetInventory.LeftHand.Icon;
        }

        Redraw();
    }

    void Redraw()
    {
        for(int i = 0; i < TargetInventory.InventoryItems.Count; i++)
		{
            var Item = TargetInventory.InventoryItems[i];
            var IconObject = new GameObject("Icon");

            IconObject.AddComponent<Image>().sprite = Item.Icon;

            Debug.Log(IconObject);

            IconObject.transform.SetParent(ItemsPanel);
        }
    }
}
