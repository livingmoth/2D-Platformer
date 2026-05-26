using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChanger : MonoBehaviour
{
    public string sceneName;
    public CoinComponent coinComponent;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(sceneName);
        // dodaj to zeby coins sie liczylo i tylko jak masz max coins to mozesz zmienic poziom
        // coœ z coin counter????
    }


}
