using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton 
{
    public static Singleton Instance;

    public Singleton() { }

    public static Singleton GetInstance()
    {
        if (Instance == null) Instance = new Singleton();

        return Instance;
    }
}
