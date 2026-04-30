using UnityEngine;

public class KillSpike : MonoBehaviour

{
    public float Damage = 1;
    public PlayerHealth health;

    public delegate void KillDelegate(PlayerHealth health);
    public event KillDelegate Onkill;
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
        //Destroy(collision.gameObject);
        collision.GetComponent<PlayerHealth>().AddDamage(Damage);
       
       
    }


}
