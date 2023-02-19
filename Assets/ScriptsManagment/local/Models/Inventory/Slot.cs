using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models.Inventory
{
    public class Slot : MonoBehaviour
    {
        public bool ActiveItem;
        public TypesItem Type;

        private Color DefaultColor;
        private bool isHighlighted;

        RaycastHit2D rayHit;


        public bool IsActive()
        {
            return ActiveItem;
        }

        void Start()
        {
            DefaultColor = transform.GetComponent<UnityEngine.UI.Image>().color;
        }

        void Update()
        {
            rayHit = Physics2D.Raycast(transform.position, Vector2.one);

            if (rayHit.collider.CompareTag("Item"))
            {
                this.isHighlighted = true;
            }
            else this.isHighlighted = false;

            if (this.isHighlighted) transform.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            else transform.GetComponent<UnityEngine.UI.Image>().color = DefaultColor;
        }
    }
}

