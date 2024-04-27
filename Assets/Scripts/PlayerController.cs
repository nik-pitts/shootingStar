using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joystick;
    public float speed = 5f;
    private CharacterController controller;
    public bool moving = false;
    private Vector3 move;
    private Vector3 direction;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        //direction = new Vector3(joystick.Direction.x, 0.0f, joystick.Direction.y);
        if (move != Vector3.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        var targetAngle = Mathf.Atan2(joystick.Direction.x, joystick.Direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        controller.Move(move * speed * Time.deltaTime);
    }
}
