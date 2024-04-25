using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joystick;
    public float speed = 5f;
    private CharacterController controller;
    public bool moving = false;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        if (move != Vector3.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        controller.Move(move * speed * Time.deltaTime);
    }
}
