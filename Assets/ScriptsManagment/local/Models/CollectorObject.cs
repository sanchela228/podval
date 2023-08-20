using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class CollectorObject
    {
        public string Path;
        public Collector.Types Type;

        public CollectorObject(string _path, Collector.Types _type)
        {
            Path = _path;
            Type = _type;
        }
    }
}
