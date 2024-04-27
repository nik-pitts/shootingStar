using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingStarMove : MonoBehaviour
{
    public GameObject player;
    public Animator starAnimation;
    private const int Distance = 10;
    private const float Speed = 5f;
    private PlayerController pc;

    private void Start()
    {
        pc= player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // location of the player
        Vector3 playerPos = player.transform.position;
        //Vector3 playerDir = player.transform.eulerAngles;
        
        // case 1. player is moving
        if (pc.moving)
        {
            //Vector3 newStarPos = GetTerrainPos(playerPos.x, playerPos.z);
            Vector3 movingVector = new Vector3(pc.joystick.Direction.x, 0.0f, pc.joystick.Direction.y);
            transform.rotation = player.transform.rotation;
            transform.Translate(movingVector * Speed * Time.deltaTime);
            transform.position = GetTerrainPos(transform.position.x, transform.position.z);
            starAnimation.ResetTrigger("Sit");
            starAnimation.SetTrigger("Jog");
        }
        // case 2. player is not moving
        else
        {
            starAnimation.ResetTrigger("Jog");
            starAnimation.SetTrigger("Sit");
        }
    }
    
    public Vector3 GetTerrainPos(float x, float z)
    {
        //Create object to store raycast data
        RaycastHit hit;

        //Create origin for raycast that is above the terrain. I chose 100.
        Vector3 origin = new Vector3(x, 100, z);

        //Send the raycast.
        Physics.Raycast(origin, Vector3.down, out hit, Mathf.Infinity);
        
        return hit.point;
    }
}
