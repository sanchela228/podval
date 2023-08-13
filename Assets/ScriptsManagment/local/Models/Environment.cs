using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Models
{
    [Serializable]
    abstract public class Environment : BaseScriptableObject
    {
        public string Name;
        public Sprite Icon;

        [TextArea]
        public string Description;

        public abstract void Click(MapObject _mapObject);

        public abstract void Change<T>(T item, string v = null);

        
    }
}