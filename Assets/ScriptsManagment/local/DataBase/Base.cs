using Models;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace DataBase
{
    public class Base : MonoBehaviour
    {
        public ItemsDataBase ItemsDataBase;

        public List<Item> GetListItem()
        {
            return ItemsDataBase.listItem;
        }
    }
}


