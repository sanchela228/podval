using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class InterfaceController
    {
        public static List<GameObject> ListUI = new List<GameObject>();

        InterfaceController()
        {

        }

        public static void LoadUIItem(GameObject UI)
        {
            ListUI.Add(UI);
            UI.SetActive(false);
        }

        public static void ToggleUIActive(GameObject UI)
        {
            if (UI.activeSelf) UI.SetActive(false);
            else UI.SetActive(true);
        }

    }
}


