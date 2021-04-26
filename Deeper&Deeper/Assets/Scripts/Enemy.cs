using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathparticles;
    [SerializeField] private Animator brain;

    [SerializeField] private CapsuleCollider2D hit;
    [SerializeField] private BoxCollider2D damage;
    [SerializeField] private CircleCollider2D detection;
    

    [SerializeField] private float DmgPerHit;

    [SerializeField] private HealthBar playerHealth;

    //UNIT GETS KILLED INSTANTLY, it is godmode after all.
    public void Hit()
    {
        //tell the animator/brain this unit has died
        StartCoroutine(Death());
    }



    IEnumerator Death()
    {
        damage.enabled = false;
        hit.enabled = false;
        deathparticles.Play();
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerHealth.Damage(DmgPerHit);
        }
    }


}
