using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
	[Serializable]
	public class Item : BaseScriptableObject
    {
		public string Name;
		public Sprite Icon;
		public bool _isUserProperty = false;
		public TypesItem Type;

		[TextArea]
		public string Description;
	}
}



