using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health 
{
    protected int def = 100;
    public int max;
    public int current;

    public Health()
    {
        max = def;
        current = max - 19;
    }

}
