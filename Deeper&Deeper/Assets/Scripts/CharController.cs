using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharController : MonoBehaviour
{
    [SerializeField] private float JumpForce = 10f;

    [SerializeField] private BoxCollider boxcol;
    [SerializeField] private CapsuleCollider capcol;

    [SerializeField] private LayerMask WhatIsGround;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private Transform CeilingCheck;


    private Rigidbody rigidbod;

    public UnityEvent OnLandEvent;



    private void Awake()
    {
        rigidbod = GetComponent<Rigidbody>();
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
