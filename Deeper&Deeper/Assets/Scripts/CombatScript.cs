using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    [Header("Aim")]
    [SerializeField]private PlayerMovement playerMovement;
    [SerializeField] private Transform twistPoint;

    [SerializeField] private float returnTime = .0f;


    [Header("Dash")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float DashSpeed;
    [SerializeField] private float dashTime = 1f;
    public bool startDashTime = false;
    [SerializeField] private Transform forceOrigin;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Aim
        
        Dash();
        Aim();
    }

    private void Dash()
    {
        float HorizontalAxis = Input.GetAxis("HorizontalRightStick");
        float VerticalAxis = Input.GetAxis("VerticalRightStick");
        Vector3 moveDir = new Vector3(VerticalAxis, HorizontalAxis).normalized; //these might need to be flipped


        //Dash
        if (startDashTime == true)
        {
            if(rb.velocity.magnitude < 700f)
            {
                rb.AddForce(twistPoint.up * DashSpeed * 10);
                startDashTime = false;
            }
            
        }
    }

    public void Aim()
    {
        Vector3 angle = twistPoint.transform.localEulerAngles;
        float HorizontalAxis = Input.GetAxis("HorizontalRightStick");
        float VerticalAxis = Input.GetAxis("VerticalRightStick");

        twistPoint.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(HorizontalAxis, VerticalAxis) * -180 / Mathf.PI + 90f);

        if(HorizontalAxis == 0f && VerticalAxis == 0f)
        {
            Vector3 currentRotation = twistPoint.transform.localEulerAngles;
            Vector3 homeRotation;

            if(currentRotation.z > 180f)
            {
                homeRotation = new Vector3(0f, 0f, 359.999f);
            }
            else
            {
                homeRotation = Vector3.zero;
            }

            twistPoint.transform.localEulerAngles = Vector3.Slerp(currentRotation, homeRotation, Time.deltaTime * returnTime);
        }

        else
        {
            twistPoint.transform.localEulerAngles = new Vector3(0f, 0f, Mathf.Atan2(HorizontalAxis, VerticalAxis) * -180 / Mathf.PI + 90f);
        }
    }
}
