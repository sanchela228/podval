using Models.Environments;
using Models.Inventory;
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
            var spriteComponent = this.GetComponent<SpriteRenderer>();

            if (spriteComponent != null && spriteComponent.sprite == null && Environment != null && Environment.Icon != null)
            {
                spriteComponent.sprite = Environment.Icon;
            }
        }

        private void OnMouseDown()
        {
            Environment.Click(this);
        }

        public void InstantiateElement()
        {
            Instantiate(this.GetComponent<GameObject>(), new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

}
