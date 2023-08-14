using Models;
using Models.Environments;
using Models.Items;
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
            Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
            var test = camera.ScreenToWorldPoint(Input.mousePosition);
            test.z = 0;

            GameObject prefab = UnityEngine.Object.Instantiate<GameObject>(
                ResourcesItem,
                test,
                Quaternion.identity
            );

            Chest objectscript = UnityEngine.Object.Instantiate<Chest>(
                Resources.Load<Chest>("ScriptableObject/Data/Environments/GayChest")
            );

            Head objectHead = UnityEngine.Object.Instantiate<Head>(
                Resources.Load<Head>("ScriptableObject/Data/Items/Head")
            );

            Body objectHBody = UnityEngine.Object.Instantiate<Body>(
                Resources.Load<Body>("ScriptableObject/Data/Items/Armor")
            );

            objectHBody.Id = Guid.NewGuid().ToString();
            objectHead.Id = Guid.NewGuid().ToString();
            objectscript.Items.Add(objectHead);
            objectscript.Items.Add(objectHBody);

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
