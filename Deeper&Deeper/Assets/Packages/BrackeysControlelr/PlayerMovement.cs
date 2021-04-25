using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] private CharacterController2D controller;
	[SerializeField] private CombatScript combatScript;
	public bool cooldowntime = false;
	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;

	[SerializeField] private Animator animator;
	
	// Update is called once per frame
	void Update () {


		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("speed", Mathf.Abs(horizontalMove));

		Jump();


	}

    private void Jump()
    {
		float HorizontalAxis = Input.GetAxis("Horizontal");
		float VerticalAxis = Input.GetAxis("Vertical");
		float trigger = Input.GetAxis("Triggers");


		if ((Input.GetButtonDown("Jump")) || VerticalAxis == 1 || Input.GetKeyDown("joystick button 0"))
		{
			jump = true;
		}

		if((trigger > 0)&&(cooldowntime == false))
        {
			Debug.Log("Right trigger pressed");
			combatScript.startDashTime = true;
			cooldowntime = true;
			StartCoroutine(Cooldown());
        }


		if (trigger > 0)
		{
			Debug.Log("left trigger pressed");
			
		}
	}



    void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}


	IEnumerator Cooldown()
    {
		yield return new WaitForSeconds(1f);
		cooldowntime = false;
	}
}
