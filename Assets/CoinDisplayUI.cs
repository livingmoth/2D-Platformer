using System;
using TMPro;
using UnityEngine;
using System.Collections;

public class CoinDisplayUI : MonoBehaviour
{
    public TextMeshProUGUI coinAmmount;
    public CoinComponent coinComponent;
    private float time = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinComponent.OnCoinChanged += OnCoinChanged;
        
    }


    public void OnCoinChanged(float Coins, float ammountChanged)
    {
        coinAmmount.text = Coins.ToString();
        coinAmmount.color = Color.yellow;
        StartCoroutine(BackToWhite(time, ResetColor));
               
    }

    IEnumerator BackToWhite(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();    
    }

    private void ResetColor()
    {
        coinAmmount.color = Color.white;    
    }




}
