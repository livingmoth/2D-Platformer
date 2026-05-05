using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Void : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
