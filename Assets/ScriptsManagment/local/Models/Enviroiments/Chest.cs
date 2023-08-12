using UnityEngine;
using UnityEngine.UI;

namespace Models.Environments
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Assets/Environments/Chest")]
    public class Chest : Environment
    {
        public GameObject Interface;

        public override void Click()
        {
            /* open interface */
            Controllers.InterfaceController.ToggleInteractiveUI(Interface);
        }
    }
}