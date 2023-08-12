using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    
    public class MapObject : MonoBehaviour
    {
        public Environment Environment;

        private void OnBecameVisible()
        {
            Sprite EnvIcon = Environment.Icon;
            var spriteComponent = this.GetComponent<SpriteRenderer>();

            spriteComponent.sprite = EnvIcon;
        }

        private void OnMouseDown()
        {
            Environment.Click();
        }

        public void InstantiateElement()
        {
            Instantiate(this.GetComponent<GameObject>(), new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

}
