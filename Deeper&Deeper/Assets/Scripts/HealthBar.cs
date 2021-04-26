using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private SO_Stats stats;
    [SerializeField] private CharacterController2D controller;


    public float health;
    public float maxHealth;

    public AnimationCurve flashCurve = new AnimationCurve();

    public Color originalFullColor = Color.green;
    public Color originalEmptyColor = Color.red;

    public Image healthBarImage = null;
    public Image animatedHealthBarImage = null;

    private float whiteFlashTimer = 1.0f;

    private bool immune = false;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = stats.maxHealth;
        health = stats.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        whiteFlashTimer += Time.deltaTime;

        var currentHealthBarColor = Color.Lerp(originalEmptyColor, originalFullColor, health / maxHealth);
        var flash = flashCurve.Evaluate(whiteFlashTimer);
        var flashColor = Color.Lerp(currentHealthBarColor, Color.white, flash);
        var scaleAnimation = flash * 0.2f + 1;

        healthBarImage.color = flashColor;
        GetComponent<RectTransform>().localScale = new Vector3(scaleAnimation, scaleAnimation, scaleAnimation);

        animatedHealthBarImage.rectTransform.sizeDelta = Vector2.Lerp(animatedHealthBarImage.rectTransform.sizeDelta, healthBarImage.rectTransform.sizeDelta, 0.005f);
        animatedHealthBarImage.color = new Color(flashColor.r * 0.5f, flashColor.g * 0.5f, flashColor.b * 0.5f);
    }

    void SetHealth(float value) {
        health = value;
        
        if (healthBarImage != null) {
            healthBarImage.rectTransform.sizeDelta = new Vector2(health / maxHealth, healthBarImage.rectTransform.sizeDelta.y);
            animatedHealthBarImage.rectTransform.sizeDelta = new Vector2(health / maxHealth, animatedHealthBarImage.rectTransform.sizeDelta.y);
        }
    }

    void DecreaseHealth(float amount) {
        if (immune == false) { 
            if (health <= 0.0f) {
                return;
            }

            float newHealth = health - amount;
            StartCoroutine(ImunityTime(amount));

            whiteFlashTimer = 0.0f;
            if (newHealth <= 0.0f) {
            
                newHealth = 0.0f;
            }
            health = newHealth;

            if(health == 0.0f)
            {
                controller.Death();
            }
            Debug.Log("we are on: " + health);
            if (healthBarImage != null) {
                healthBarImage.rectTransform.sizeDelta = new Vector2(health / maxHealth, healthBarImage.rectTransform.sizeDelta.y);
            }
        }
    }


    public void Damage(float amount)
    {
        DecreaseHealth(amount);
    }

    public void Heal(float amount)
    {
        SetHealth(amount);
    }

    IEnumerator ImunityTime(float amount)
    {
        immune = true;
        yield return new WaitForSeconds(amount/10);
        immune = false;
    }
}
