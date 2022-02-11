using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DataBase.XML
{
    [System.Serializable]
    public class XMLManager : Singleton
    {
        // Singleton extension "of"course 
        // xml working
        public void test()
        {
            var instance = XMLManager.GetInstance();
        }

        
    }


}

