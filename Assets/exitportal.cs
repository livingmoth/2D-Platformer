using UnityEngine;

public class exitportal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}

   
