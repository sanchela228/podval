using System;
using System.Collections.Generic;
using Models;
using UnityEngine;

public static class Collector
{
    public enum Types { Prefab, ScriptableObject }

    private static Dictionary<string, CollectorObject> Collection = new Dictionary<string, CollectorObject>()
    {
        // prefabs ----------------------
        ["MapObject"] = new CollectorObject("Prefabs/MapObject", Collector.Types.Prefab),

        // ScriptableObject -------------
        ["64d2feee-a529-4b13-ac53-e10adbb50c28"] = new CollectorObject("ScriptableObject/Data/Items/Armor", Collector.Types.ScriptableObject),
        
    };

    public static object Get(string key, bool Copy = true)
    {
        if (Collection.ContainsKey(key))
        {
            if (!Copy) return Resources.Load(Collection[key].Path);

            return UnityEngine.Object.Instantiate(
                Resources.Load(Collection[key].Path)
            );
        }
        else throw new Exception("Cannot find this key in collection");
    }

    public static object Get(string key, Vector3 pos = new Vector3())
    {
        if (Collection.ContainsKey(key))
        {
            switch (Collection[key].Type)
            {
                case Types.ScriptableObject:
                    return UnityEngine.Object.Instantiate(
                        Resources.Load(Collection[key].Path)
                    );

                case Types.Prefab:
                    return UnityEngine.Object.Instantiate(
                        Resources.Load(Collection[key].Path),
                        pos,
                        Quaternion.identity
                    );

                default: return null;
            }
        }
        else throw new Exception("Cannot find this key in collection");
    }
}