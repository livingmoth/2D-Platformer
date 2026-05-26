using System;
using System.Collections;
using UnityEngine;


public class exitportal : MonoBehaviour
{
    public float portalTimer = 10;
    public bool CanTeleport = true;
    public Transform teleportTarget;
    public Teleport tl;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (CanTeleport == true)
        {
            collision.transform.position = teleportTarget.position;
            CanTeleport = false;
            tl.CanTeleport = false;
            StartCoroutine(PortalTimer(portalTimer, ResetTimer));
             
        }
        
        
        
    }
    IEnumerator PortalTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();

    }
    private void ResetTimer()
    {
        CanTeleport = true;
        tl.CanTeleport = true;
        

    }
    


}

   
