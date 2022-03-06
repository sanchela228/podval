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

        private XmlDocument _xmlDocument;
        private string _nameXmlSelected;

        public XMLManager(string Name = "UserData")
        {
            _nameXmlSelected = Name;

            _xmlDocument = new XmlDocument();
            _xmlDocument.Load(Application.dataPath + "/XMLData/"+ _nameXmlSelected + ".xml");
           
        }

        public void SetProperty(string property, string value = null)
        {
            var XMLproperty = _xmlDocument.SelectSingleNode("/user/" + property);
            if (value != null) XMLproperty.InnerXml = value;

            Save();
        }

        public string GetProperty(string property)
        {
            var XMLproperty = _xmlDocument.SelectSingleNode("/user/" + property);

            return XMLproperty.InnerXml;
        }

        protected void Save()
        {
            _xmlDocument.Save(Application.dataPath + "/XMLData/" + _nameXmlSelected + ".xml");
        }
    }


}

