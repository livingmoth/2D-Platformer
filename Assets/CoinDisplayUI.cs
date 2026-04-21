using System;
using TMPro;
using UnityEngine;

public class CoinDisplayUI : MonoBehaviour
{
    public TextMeshProUGUI coinAmmount;
    public CoinComponent coinComponent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinComponent.OnCoinChanged += OnCoinChanged;
        
    }


    public void OnCoinChanged(float Coins, float ammountChanged)
    {
        //Debug.Log("On Health Changed event");
        coinAmmount.text = Coins.ToString();
        
    }



}
