using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    [SerializeField] CircleCollider2D detectionField;
    [SerializeField] Animator brain;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
                brain.SetBool("TargetSpotted", true);
        }
    }
}
