using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;

    public float smoothspeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredposition = target.position + offset;
        Vector3 smoothposition = Vector3.Lerp(transform.position, desiredposition, smoothspeed);
        transform.position = smoothposition;
    }
}
