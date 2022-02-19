using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System;

namespace DataBase.XML
{
    [System.Serializable]
    public class XMLManager
    {
        public XMLUser _userData;

        private XmlDocument xmlDocument;
        private string _nameXmlSelected;

        public XMLManager(string Name = "UserData")
        {
            _nameXmlSelected = Name;

            xmlDocument = new XmlDocument();
            xmlDocument.Load(Application.dataPath + "/XMLData/"+ _nameXmlSelected + ".xml");
           
        }

        public void SetProperty(string property, string value = null)
        {
            var XMLproperty = xmlDocument.SelectSingleNode("/user/" + property);
            if (value != null) XMLproperty.InnerXml = value;

            Save();
        }

        public string GetProperty(string property)
        {
            var XMLproperty = xmlDocument.SelectSingleNode("/user/" + property);

            return XMLproperty.InnerXml;
        }

        private void Save()
        {
            xmlDocument.Save(Application.dataPath + "/XMLData/" + _nameXmlSelected + ".xml");
        }
    }


}

