using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DataBase
{
    public class Base
    {
        public static List<Item> itemList;

        public static List<Item> GetItemsList()
        { 
            return itemList;
        }
    }
}


