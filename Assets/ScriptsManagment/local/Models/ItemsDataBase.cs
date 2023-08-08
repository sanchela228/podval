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
    }
}

