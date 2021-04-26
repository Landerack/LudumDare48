using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInstaKill : MonoBehaviour
{
    public Collider2D playerdetector;
    public TransitionExampleCaller scenetrans;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            scenetrans.SceneUp();
        }
    }
}
