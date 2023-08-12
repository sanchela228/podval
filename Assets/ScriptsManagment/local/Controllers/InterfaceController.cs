using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Controllers
{
    public class InterfaceController
    {
        public static List<GameObject> ListUI = new List<GameObject>();
        public GameObject potchPrf;

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

        public static void ToggleInteractiveUI(GameObject interactiveInterface)
        {
            GameObject interfaceMain = ListUI.Find(b => b.name == "InterectiveUI");
            ToggleUIActive(interfaceMain);

            if (interfaceMain.active)
            {
                GameObject prefab = UnityEngine.Object.Instantiate<GameObject>(
                    interactiveInterface, 
                    new Vector3(0, 0, 0), 
                    Quaternion.identity
                );

                prefab.transform.SetParent(interfaceMain.transform, false);
            }
            else UnityEngine.Object.Destroy( interfaceMain.transform.GetChild(0).gameObject );
        }

    }
}


