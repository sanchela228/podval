using Models;
using Models.Environments;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public double moveSpeed;
    public Rigidbody2D rbUser;

    Vector2 movment;


    void Update()
    {
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");



        // tests
        if (Input.GetKeyUp(KeyCode.K))
        {
            var ResourcesItem = Resources.Load<GameObject>("Prefabs/MapObject");

            GameObject prefab = UnityEngine.Object.Instantiate<GameObject>(
                ResourcesItem,
                new Vector3(0, 0, -2),
                Quaternion.identity
            );

            Chest objectscript = UnityEngine.Object.Instantiate<Chest>(
                Resources.Load<Chest>("ScriptableObject/Data/Environments/GayChest")
            );

            prefab.GetComponent<MapObject>().Environment = objectscript;

            //Debug.Log(objectscript);
        }

           
    }

    void FixedUpdate()
    {
        Movment();
    }

    protected void Movment()
	{
        var direction = movment.x + movment.y;
        double speed = moveSpeed;

        if (direction == 0 || direction == 2 || direction == -2) speed = moveSpeed / 1.2;

        rbUser.MovePosition(rbUser.position + (movment * (float)speed * Time.fixedDeltaTime));
        
    }
}
