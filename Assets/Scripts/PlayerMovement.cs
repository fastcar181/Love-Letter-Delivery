using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 5;
    float speedX, speedY;
    private Rigidbody2D body;
    private static bool CanMove;
    
    // Start is called before the first frame update
    void Start()
    {
        CanMove = true;
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            speedX = Input.GetAxisRaw("Horizontal") * speed;
            speedY = Input.GetAxisRaw("Vertical") * speed;
            body.velocity = new Vector2(speedX, speedY);

        }
    }

    public static void SetMove(bool move)
    {
        CanMove = move;
    }
}