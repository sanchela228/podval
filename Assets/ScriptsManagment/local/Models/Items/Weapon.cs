using Interfaces;
using UnityEngine;

namespace Models.Items
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Assets/Items/Weapon")]
    public class Weapon : Item
    {
        public enum TypeHit { Projectile, Melee }

        public ISkill Skill;

        public int Damage;
        public int countProjectiles;
        public TypeHit Typehit;

        public void Hit()
        {
            switch (Typehit) 
            {
                case TypeHit.Projectile: 
                    
                    
                    
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