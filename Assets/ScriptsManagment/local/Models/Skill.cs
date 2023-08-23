using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Models
{
    public abstract class Skill : MonoScript
    {
        public abstract void Use(Vector3 direction = new Vector3(), Vector3 startPos = new Vector3());
    }
}