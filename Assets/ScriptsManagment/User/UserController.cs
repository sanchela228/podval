using System.Collections;
using System.Collections.Generic;
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
