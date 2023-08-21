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
        public bool DestroyMe;

        [TextArea]
        public string Description;

        public abstract void Click(MapObject _mapObject);

        public abstract void Change<T>(T i, string v = null);

        public abstract void UpdatePerFrame(MapObject _mapObject, string v = null);
    }
}