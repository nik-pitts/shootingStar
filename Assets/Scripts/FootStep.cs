using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private ClickController cc;

    public AudioSource footstepSound;
    // Start is called before the first frame update
    void Start()
    {
        cc = player.GetComponent<ClickController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.playerDirection != Vector3.down)
        {
            footstepSound.enabled = true;
        }
        else
        {
            footstepSound.enabled = false;
        }
    }
}
