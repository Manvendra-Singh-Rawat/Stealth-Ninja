using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player : MonoBehaviour
{
    [SerializeField]
    private float playerspeed = 4.0f;
    private float _jumpheight = 12.0f;
    private float _yvelocity;
    private bool groundedplayer;
    private float gravityvalue = 1.0f;

    private CharacterController _controller;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        player_movement();
    }

    private void player_movement()
    {
        Vector3 direction = new Vector3(-1 * Input.GetAxis("Vertical"), _yvelocity, Input.GetAxis("Horizontal"));

        Vector3 velocity = direction * playerspeed;
        
        if(_controller.isGrounded == true)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                _yvelocity = _jumpheight;
            }
        }
        else
        {
            _yvelocity = _yvelocity - gravityvalue;
        }

        velocity.y = _yvelocity;

        _controller.Move(velocity * Time.deltaTime);
    }
}
