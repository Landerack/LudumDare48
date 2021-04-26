using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float aimDistance = 2f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.transform.position + new Vector3(0f,0f, aimDistance);
    }
}
