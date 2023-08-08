using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "Box", menuName = "Assets/InteractiveUIElement")]
    public class BoxObject : BaseScriptableObject
    {
        public string Name;
        public Transform ElementUI;

    }

}
