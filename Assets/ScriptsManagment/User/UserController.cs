using Models;
using Models.Environments;
using Models.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class UserController : MonoBehaviour
{
    public double moveSpeed;
    public Rigidbody2D rbUser;

    Vector2 movment;

    public Health Health = new();

    private GameObject[] objectarrays;
    private GameObject[] objectarrays2;

    void Update()
    {
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");

        // tests
        if (Input.GetKeyUp(KeyCode.L))
        {
            // GameObject map = (GameObject) Collector.Get("MapObject", true);

            // Debug.Log(test);
            // Debug.Log(map);
        }


        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            objectarrays2 = GameObject.FindGameObjectsWithTag("MapObject");
            objectarrays = GameObject.FindGameObjectsWithTag("MapItem");


            if (objectarrays.Length > 0)
            {
                foreach (var item in objectarrays)
                {
                    item.GetComponent<MapItem>().TextMesh.SetActive(true);
                }
            }

            if (objectarrays2.Length > 0)
            {
                foreach (var item in objectarrays2)
                {
                    item.GetComponent<MapObject>().TextMesh.SetActive(true);
                }
            }

        }

        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            if (objectarrays.Length > 0)
            {
                foreach (var item in objectarrays)
                {
                    item.GetComponent<MapItem>().TextMesh.SetActive(false);
                }
            }

            if (objectarrays2.Length > 0)
            {
                foreach (var item in objectarrays2)
                {
                    item.GetComponent<MapObject>().TextMesh.SetActive(false);
                }
            }
        }

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

            Weapon objectHBody = UnityEngine.Object.Instantiate<Weapon>(
                Resources.Load<Weapon>("ScriptableObject/Data/Items/Weapons/ProjWeapon")
            );

            objectHBody.Id = Guid.NewGuid().ToString();
            objectHead.Id = Guid.NewGuid().ToString();
            objectscript.Items.Add(objectHead);
            objectscript.Items.Add(objectHBody);

            prefab.GetComponent<MapObject>().Environment = objectscript;


            // Debug.Log(objectscript);
        }


        UserLeftClick();


    }

    void FixedUpdate()
    {
        Movment();
    }

    protected void UserLeftClick()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            GetComponent<UserInventory>().Weapon?.Hit(
                Camera.main.ScreenToWorldPoint(Input.mousePosition), 
                rbUser.position
            );
        }

    }

    protected void Movment()
	{
        var direction = movment.x + movment.y;
        double speed = moveSpeed;

        if (direction == 0 || direction == 2 || direction == -2) speed = moveSpeed / 1.2;

        rbUser.MovePosition(rbUser.position + (movment * (float) speed * Time.fixedDeltaTime));
    }
}
