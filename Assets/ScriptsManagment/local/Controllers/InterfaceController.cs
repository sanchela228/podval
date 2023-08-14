using System.Collections.Generic;
using UnityEngine;
using Models.Inventory;

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

        public static GameObject ToggleInteractiveUI(GameObject interactiveInterface)
        {
            GameObject prefab = null;

            GameObject interfaceMain = ListUI.Find(b => b.name == "InterectiveUI");
            ToggleUIActive(interfaceMain);

            if (interfaceMain.activeSelf)
            {
                prefab = UnityEngine.Object.Instantiate<GameObject>(
                    interactiveInterface,
                    new Vector3(0, 0, 0),
                    Quaternion.identity
                );

                prefab.transform.SetParent(interfaceMain.transform, false);
            }
            else UnityEngine.Object.Destroy(interfaceMain.transform.GetChild(0).gameObject);
            
            return prefab;
        }

        public static void PutItemsInInterface(GameObject Interface, List<Models.Item> Items)
        {
            var ResourcesItem = Resources.Load<GameObject>("Prefabs/Item");    

            for (int i = 0; i < Interface.transform.childCount;  i++)
            {
                var interfaceGameObject = Interface.transform.GetChild(i).gameObject;
               
                if (interfaceGameObject.CompareTag("SlotForItem"))
                {
                    if (Items.Count >= (i + 1) && Items[i])
                    {
                        GameObject prefab = UnityEngine.Object.Instantiate<GameObject>(
                            ResourcesItem,
                            new Vector3(0, 0, -2),
                            Quaternion.identity
                        );

                        interfaceGameObject.transform.GetComponent<Slot>().ItemObject = Items[i];
                        prefab.GetComponent<ItemObject>().Item = Items[i];

                        prefab.transform.SetParent(interfaceGameObject.transform, false);
                    }
                }
            }



        }
    }
}