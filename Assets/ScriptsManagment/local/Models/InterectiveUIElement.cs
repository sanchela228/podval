using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class InterectiveUIElement : MonoBehaviour
    {
        public BoxObject BoxObject;
        public GameObject UIElement;


        public void OnMouseDown()
        {
            GameObject interac = Controllers.InterfaceController.ListUI.Find(b => b.name == "InterectiveUI");
            Controllers.InterfaceController.ToggleUIActive(interac);
        }


    }
}

