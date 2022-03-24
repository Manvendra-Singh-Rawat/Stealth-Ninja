using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animation : MonoBehaviour
{
    private Animator animat;

    void Start()
    {
        animat = GetComponent<Animator>();
    }

    public void movement()
    {
        animat.SetInteger("walking", 1);
    }

    public void stop_move()
    {
        animat.SetInteger("walking", 0);
    }
}
