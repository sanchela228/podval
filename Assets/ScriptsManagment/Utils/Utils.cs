using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static string CamelCaseToLowerString(string Value, bool replaceString = true)
    {
        if (replaceString && Value != null) Value = Value.Trim( new Char[] { ' ', '_', '.', ',', '/' } );

        return Value.ToLower();
    }
}
