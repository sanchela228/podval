using UnityEngine;

namespace Interfaces
{
    public interface ISkill
    {
        public void Use(Vector3 direction = new Vector3(), Vector3 startPos = new Vector3());
    }
}