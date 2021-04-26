using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spouters : MonoBehaviour
{
    public GameObject spouter;
    public float timer;
    public Collider2D spoutercol;
    public HealthBar playerhp;
    private bool active = false;

    void Start()
    {
            StartCoroutine(EnableDisable());
    }

    IEnumerator EnableDisable()
    {
        
        spouter.SetActive(true);
        yield return new WaitForSeconds(timer);
        spouter.SetActive(false);
        yield return new WaitForSeconds(timer);
        StartCoroutine(EnableDisable());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerhp.Damage(20f);
        }
    }
}
