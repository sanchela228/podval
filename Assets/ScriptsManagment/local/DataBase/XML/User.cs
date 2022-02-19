using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;


namespace DataBase.XML
{
    [System.Serializable]
    public class XMLUser
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public string RightHeand { get; set; }
        public string Head { get; set; }
        public string Body { get; set; }

        public Guid[] InventoryItems;
    }
}

