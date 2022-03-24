using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySight : MonoBehaviour
{
    public GameObject eyes;
    public GameObject player;
    float maxFOVangle = 45f;
    float lookRadius = 10f;

    public bool sighted = false;

    private touch_movement_player _player;
    
    void Start()
    {
        _player = GameObject.Find("player").GetComponent<touch_movement_player>();
    }

    void Update()
    {
        Vector3 fovRadius = eyes.gameObject.transform.forward * lookRadius;
        float playerAngle = Vector3.Angle(player.transform.position - eyes.transform.position, fovRadius);

        Vector3 direction = (-eyes.transform.position + player.transform.position);

        if (playerAngle < maxFOVangle)
        {
            Debug.DrawRay(eyes.transform.position, direction);
            RaycastHit hit;
            if (Physics.Raycast(eyes.transform.position, direction, out hit, lookRadius))
            {
                if (hit.transform.tag == "Player")
                {
                    Debug.Log("ishitting");
                    sighted = true;
                    _player.detection();
                }
            }
        }
        else
        {
            sighted = false;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
