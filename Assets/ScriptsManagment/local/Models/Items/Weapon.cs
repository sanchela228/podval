using Interfaces;
using UnityEditor;
using UnityEngine;

namespace Models.Items
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Assets/Items/Weapon")]
    public class Weapon : Item
    {
        public enum TypeHit { Projectile, Melee }

        public Skill Skill;

        public int Damage;
        public int countProjectiles = 1;
        public int sizeProjectiles = 10;
        public int distanceProjectiles = 10;
        public TypeHit Typehit;
        public Sprite hitSprite;

        public void Hit(Vector3 direction)
        {
            switch (Typehit) 
            {
                case TypeHit.Projectile:
                    direction.z = 2;
                    GameObject Hit = (GameObject) Collector.Get("Hit", direction);

                    Hit.GetComponent<SpriteRenderer>().sprite = hitSprite;
                    Hit.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeProjectiles, 20);



                    break;

                case TypeHit.Melee: 
                    
                    
                    
                break;

                default: return;
            }
        }

        public void UseSkill(Vector3 direction = new Vector3(), Vector3 startPos = new Vector3())
        {
            Skill?.Use(direction, startPos);
        }
    }
}