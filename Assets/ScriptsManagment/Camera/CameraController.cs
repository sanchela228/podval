using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = GameObject.Find("MainPlayer").transform;
    }

	void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = player.position.x;
        cameraPosition.y = player.position.y;

        transform.position = cameraPosition;
    }
}
