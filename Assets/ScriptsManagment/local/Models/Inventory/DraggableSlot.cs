using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DraggableSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector3 StartPositionDrag;


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin");
      // .// Debug.Log(eventData.);
       // Debug.Log(eventData.position);
        Debug.Log(Input.mousePosition);
        //transform.localPosition= eventData.position;
        //StartPositionDrag = (Vector3) eventData.;

        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(diference);
        Debug.Log("------");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("inner");
        //Debug.Log(eventData.position);
        Debug.Log(Input.mousePosition);
        //Debug.Log(eventData.delta);
        //transform.position = (Vector3) eventData.position;
        transform.localPosition = eventData.position;
        Debug.Log("------");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end");
        Debug.Log(Input.mousePosition);
        //transform.position = StartPositionDrag;

        Debug.Log("------");
    }
}
