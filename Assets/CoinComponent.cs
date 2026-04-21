using System;
using System.Collections;
using UnityEngine;

public class CoinComponent : MonoBehaviour
{
    public float StartingCoins = 0;
    private float Coins;
    


    public delegate void CoinChangedHandler(float newCoins, float ammountChanged);
    public event CoinChangedHandler OnCoinChanged;





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
       OnCoinChanged?.Invoke(Coins, AddCoins);

    }
}
