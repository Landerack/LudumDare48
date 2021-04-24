//The Ray Screenshaker is brought to you by Ray Robin Vermeulen. Enjoy, and feel free to use it in commercial products, just gimme a credit or something.

//The following is the list of commands possible:

//SmallHorizontalScreenshake("left"); or SmallHorizontalScreenshake("right");
//SmallVerticalScreenshake("up"); or SmallVerticalScreenshake("down");
//the same idea applies for GreatVerticalScreenshake(direction); and GreatHorizontalScreenshake(direction);

//Lastly there is the great and small rumble, these are a little special, because they keep going untill they are told to stop.
//the rumble has 2 modes: RumbleShake(size); where the size can be either "SmallRumble" and "GreatRumble"
//in order for rumble to stop you must call StopRumble(); and the camera will return to still.

//should you call for multiple screen shakes at once, only the first one will play, as only one can play at a time.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshakeDirector : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private string boolToTurn;
    private bool rumbling = false;


    public void SmallHorizontalScreenshake(string direction)
    {
        if(rumbling == false)
        {
            if (direction == "left")
            {
                boolToTurn = "SmallShake_HorLeft";
                animator.SetBool(boolToTurn, true);
                return;
            }
            else if (direction == "right")
            {
                boolToTurn = "SmallShake_HorRight";
                animator.SetBool(boolToTurn, true);
                return;
            }
            Debug.Log("Wrong SmallHorizontalScreenshake string assigned, must be left or right");
            return;
        }
        Debug.Log("Rumbling is still on.");
    }

    public void SmallVerticalScreenshake(string direction)
    {
        if (rumbling == false)
        {
            if (direction == "up")
            {
                boolToTurn = "SmallShake_VerUp";
                animator.SetBool(boolToTurn, true);
                return;
            }
            else if (direction == "down")
            {
                boolToTurn = "SmallShake_VerDown";
                animator.SetBool(boolToTurn, true);
                return;
            }
            Debug.Log("Wrong SmallVerticalScreenshake string assigned, must be up or down");
            return;
        }
        Debug.Log("Rumbling is still on.");
    }

    public void GreatHorizontalScreenshake(string direction)
    {
        if(rumbling == false) 
        { 
            if (direction == "left")
            {
                boolToTurn = "GreatShake_HorLeft";
                animator.SetBool(boolToTurn, true);
                return;
            }
            else if (direction == "right")
            {
                boolToTurn = "GreatShake_HorRight";
                animator.SetBool(boolToTurn, true);
                return;
            }
            Debug.Log("Wrong GreatHorizontalScreenshake string assigned, must be left or right");
            return;
        }
        Debug.Log("Rumbling is still on.");
    }


    public void GreatVerticalScreenshake(string direction)
    {
        if (rumbling == false)
        {
            if (direction == "up")
            {
                boolToTurn = "GreatShake_VerUp";
                animator.SetBool(boolToTurn, true);
                return;
            }
            else if (direction == "down")
            {
                boolToTurn = "GreatShake_VerDown";
                animator.SetBool(boolToTurn, true);
                return;
            }
            Debug.Log("Wrong GreatVerticalScreenshake string assigned, must be up or down");
            return;
        }
        Debug.Log("Rumbling is still on.");
    }

    public void RumbleShake(string size)
    {
        if (rumbling == false)
        {
            if (size == "small")
            {
                boolToTurn = "SmallRumble";
                animator.SetBool(boolToTurn, true);
                rumbling = true;
                return;
            }
            else if (size == "great")
            {
                boolToTurn = "GreatRumble";
                animator.SetBool(boolToTurn, true);
                rumbling = true;
                return;
            }
            Debug.Log("Wrong RumbleShake string assigned, must be small or great");
        }
    }
    
    public void StopRumble()
    {
        animator.SetBool("SmallRumble", false);
        animator.SetBool("GreatRumble", false);
        rumbling = false;
    }
}
