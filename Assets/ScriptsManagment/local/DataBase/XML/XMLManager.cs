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
        // хочу потом сделать отдельно объекты для каждого файла для 
        // для удобного контроля и чтобы не ебаться с именами.

        //public XMLUser _userData;
        public XmlNode XMLNode;

        private XmlDocument _xmlDocument;
        private string _nameXmlSelected;

        public XMLManager(string Name)
        {
            _nameXmlSelected = Name;

            _xmlDocument = new XmlDocument();
            _xmlDocument.Load(Directory.GetCurrentDirectory() + "/Assets/XMLData/" + _nameXmlSelected + ".xml");

            XMLNode = _xmlDocument.SelectSingleNode("/" + Name);
        }

        public void SetProperty(string property, string value = null)   
        {
            var XMLproperty = XMLNode.SelectSingleNode(property);
            if (value != null) XMLproperty.InnerXml = value;

            Save();
        }

        public string GetProperty(string property)
        {
            var XMLproperty = XMLNode.SelectSingleNode(property);

            return XMLproperty.InnerXml;
        }

        protected void Save()
        {
            _xmlDocument.Save(Directory.GetCurrentDirectory() + "/Assets/XMLData/" + _nameXmlSelected + ".xml");
        }
    }
}

