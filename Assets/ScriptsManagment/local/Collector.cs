using System.Collections.Generic;
using Models;

public class Collector
{
    Dictionary<string, CollectorObject> Collection = new Dictionary<string, CollectorObject>()
    {
        ["64d2feee-a529-4b13-ac53-e10adbb50c28"] = new CollectorObject() 
        { 
        
        }
    };

    public CollectorObject Get(string Guid, bool Copy = true)
    {
        return Collection[Guid];
    }
}
