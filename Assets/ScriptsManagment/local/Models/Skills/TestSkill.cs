using Interfaces;
using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSkill : Skill
{
    public override void Use(Vector3 direction = default, Vector3 startPos = default)
    {
        Debug.Log("skill used");
    }

}
