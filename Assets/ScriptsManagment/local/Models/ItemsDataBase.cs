using System.Collections.Generic;
using UnityEngine;


namespace Models
{
    [CreateAssetMenu(fileName = "New Item DataBase", menuName = "Assets/DataBases/Item DataBase")]
    public class ItemsDataBase : BaseScriptableObject
    {
        public List<Item> listItem;
    }

}

