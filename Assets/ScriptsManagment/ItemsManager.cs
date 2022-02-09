using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SObject.Items
{
    public class CBlockItems
    {
        public List<Item> AllItems = new List<Item>();

        public static Guid GetByGuid(Guid guid)
        {
            return guid;
        }
    }
}


