using System;
using System.Collections;
using UnityEngine;


public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public exitportal tl;
   
    public bool CanTeleport = true;

  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CanTeleport == true)
        {
            collision.transform.position = teleportTarget.position;
            tl.CanTeleport = false;
            CanTeleport = false;
            StartCoroutine(portalTimer(tl.portalTimer, ResetTimer));
        }
    }

    IEnumerator portalTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();

    }
    private void ResetTimer()
    {
        tl.CanTeleport = true;
        CanTeleport = true;
        

    }
}
