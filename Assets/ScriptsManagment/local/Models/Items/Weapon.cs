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
        public Sprite hitSprite;

        public TypeHit Typehit;

        public int Damage;
        public int countProjectiles;
        public int sizeProjectiles;
        public int distanceProjectiles;
        public float speedProjectiles;

        public void Hit(Vector3 direction, Vector3 start)
        {
            switch (Typehit) 
            {
                case TypeHit.Projectile:
                    direction.z = 2;
                    GameObject Hit = (GameObject) Collector.Get("Hit", start);

                    Hit.GetComponent<SpriteRenderer>().sprite = hitSprite;
                    Hit.GetComponent<SpriteRenderer>().size = new Vector2(sizeProjectiles, 10);
                    Hit.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeProjectiles, 10);

                    float angle = Mathf.Atan2(direction.y - start.y, direction.x - start.x) * Mathf.Rad2Deg;


                    Hit.transform.rotation = Quaternion.Euler(0f, 0f, angle);
                    Hit.GetComponent<Rigidbody2D>().velocity = Hit.transform.right * speedProjectiles;


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