using System;
using System.Collections;
using UnityEngine;

public class CoinComponent : MonoBehaviour
{
    public float StartingCoins = 0;
    private float Coins;
    public PlayerHealth HealthComp;
   

    public delegate void CoinChangedHandler(float newCoins, float ammountChanged);
    public event CoinChangedHandler OnCoinChanged;

    public delegate void CoinAddedHealth(float collectedCoins);
    public event CoinAddedHealth OnCoinAddedHealth;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Coins = StartingCoins;
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  

    public void AddCoins(float AddCoins)
    {
        Coins += AddCoins;
       
        if (Coins == 10)
        {
            Coins = Coins - 10;
            HealthComp.AddHealth(10);

        }
        OnCoinChanged?.Invoke(Coins, AddCoins);

    }

}
