using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "New Item DataBase", menuName = "Assets/DataBases/Item DataBase")]
    public class ItemsDataBase : BaseScriptableObject
    {
        [SerializeField]
        private List<Item> _listItem;

        public List<Item> listItem => this._listItem;



        //private static ItemsDataBase _instance;
        //public static ItemsDataBase Instance
        //{
        //    get
        //    {
        //        if (!_instance)
        //        {
        //            _instance = Resources.<ItemsDataBase>();
        //        }


        //        return _instance;
        //    }
        //}


        //private static ItemsDataBase instance;
        //private ItemsDataBase() { }

        //public static ItemsDataBase getInstance()
        //{
        //    if (instance == null)
        //        instance = new ItemsDataBase();
        //    return instance;
        //}
    }
}

