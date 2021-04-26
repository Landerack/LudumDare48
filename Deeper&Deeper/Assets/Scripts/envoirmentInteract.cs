using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class envoirmentInteract : MonoBehaviour
{
    [SerializeField] CircleCollider2D detectionField;
    [SerializeField] Animator Interactible;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Interactible.SetTrigger("Touched");
        }
    }
}
