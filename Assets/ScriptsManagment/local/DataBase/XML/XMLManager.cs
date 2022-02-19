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
        public XMLUser _userData;

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XMLUser));

            FileStream stream = new FileStream(Application.dataPath + "/XMLData/UserData.xml", FileMode.Create);
            serializer.Serialize(stream, _userData); 
            stream.Close();
        }

        public void Read()
        {
            
            
        }
    }


}

