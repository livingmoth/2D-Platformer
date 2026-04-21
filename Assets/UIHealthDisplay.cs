using System;
using TMPro;
using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public PlayerHealth playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerHealth.OnHealthChanged += OnHealthChanged;
        playerHealth.OnHealthInitialised += OnHealthInit;
    }

    private void OnHealthInit(float newHealth)
    {
        healthText.text = newHealth.ToString();
    }

    public void OnHealthInitialized(float playerHealth)
    {

    }

    public void OnHealthChanged(float newHealth, float ammountChanged)
    {
        //Debug.Log("On Health Changed event");
        healthText.text = newHealth.ToString();
    }

  

}
