using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingStarMove : MonoBehaviour
{
    public GameObject player;
    public Animator starAnimation;
    private const float Speed = 4f;
    private ClickController cc;

    private void Start()
    {
        cc = player.GetComponent<ClickController>();
    }

    // Update is called once per frame
    void Update()
    
    {
        Vector3 movingVector = cc.playerDirection;
        // case 1. player is moving
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (movingVector != Vector3.down && distance <= 8)
        {
            // transform.rotation = player.transform.rotation;
            transform.position = GetTerrainPos(transform.position.x, transform.position.z);
            transform.Translate(movingVector * Speed * Time.deltaTime);
            
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
