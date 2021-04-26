using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour {

    [SerializeField] private CircleCollider2D detection;
    [SerializeField] private HealthBar playerhealth;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerhealth.Damage(10f);
        }
    }
}
