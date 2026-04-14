    using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    private float Health;
    private bool CanRecieveDamage = true;
    public float invincibilityTimer = 2;



    public delegate void HealthChangedHandler(float newHealth, float ammountChanged);
    public event HealthChangedHandler OnHealthChanged;

    public delegate void HealthInitialisedHandler (float newHealth);
    public event HealthInitialisedHandler OnHealthInitialised;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = MaxHealth;
        OnHealthInitialised?.Invoke(Health);
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage(float damage)
    {
        if (CanRecieveDamage)
        {
            Health -= damage;
            OnHealthChanged?.Invoke(Health, -damage);
            CanRecieveDamage = false;
            StartCoroutine(InvincibilityTimer(invincibilityTimer, ResetInvincibility));
        }



    }

    private void ResetInvincibility()
    {
        CanRecieveDamage = true;

    }

    IEnumerator InvincibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();

    }

    public void AddHealth(float HealthToAdd)
    {
        Health += HealthToAdd;
        OnHealthChanged?.Invoke(Health, HealthToAdd);

    }
}
