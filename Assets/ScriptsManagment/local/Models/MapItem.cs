using Controllers;
using Models;
using Models.Environments;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapItem : MonoBehaviour
{
    public Item Item;
    public GameObject TextMesh;

    private void OnBecameVisible()
    {
        TextMesh.transform.GetComponent<TextMeshPro>().text = Item.Name;


        //

        //if (spriteComponent != null && spriteComponent.sprite == null && Environment != null && Environment.Icon != null)
        //{
        //    spriteComponent.sprite = Environment.Icon;
        //}
    }

    private void OnMouseDown()
    {
        //Environment.Click(this);
    }

    private void Update()
    {
        //Environment.UpdatePerFrame(this);

        //if (Environment != null && Environment.DestroyMe)
        //{
        //    if (Environment is Drop) InterfaceController.CloseInteractiveInterface();
        //    Destroy();
        //}
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
