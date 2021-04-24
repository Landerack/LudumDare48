using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatBehavior : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 _startPosition;
    [SerializeField] private float floatingheight = .2f;
    [SerializeField] private float floatingspeed = 2f;
    [SerializeField] private Rigidbody2D velocityRecording;

    void Start()
    {
        _startPosition = transform.localPosition;
    }

    void Update()
    {
        if (velocityRecording.velocity.magnitude < 0.3)
        {
            //player is not moving
            transform.localPosition = _startPosition + new Vector3(0, Mathf.Sin(Time.time * floatingspeed) * floatingheight, 0.0f);
            transform.hasChanged = false;
        }


    }
}
