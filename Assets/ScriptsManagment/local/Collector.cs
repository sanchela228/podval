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
        ["7d38ddb5-7ecb-4df6-aa96-4e51adf701b4"] = new CollectorObject("ScriptableObject/Data/Items/Head", Collector.Types.ScriptableObject),
        ["b30ea009-c3f3-4c32-86d6-bbe7a2525beb"] = new CollectorObject("ScriptableObject/Data/Environments/DropItem", Collector.Types.ScriptableObject),
        ["d5d37dcb-c6ec-4865-916e-e56b615e11e3"] = new CollectorObject("ScriptableObject/Data/Environments/GayChest", Collector.Types.ScriptableObject),
    };

    public static object Get(string key)
    {
        if (Collection.ContainsKey(key))
        {
            return UnityEngine.Object.Instantiate(
                Resources.Load(Collection[key].Path)
            );
        }
        else return null;
    }

    public static object Get(string key, bool Copy)
    {
        if (Collection.ContainsKey(key))
        {
            if (!Copy) return Resources.Load(Collection[key].Path);

            return UnityEngine.Object.Instantiate(
                Resources.Load(Collection[key].Path)
            );
        }
        else return null;
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
        else return null;
    }

    public static bool Has(string key)
    {
        if (Collection.ContainsKey(key)) return true;
        else return false;
    }
}