using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Kill()
    {
        GetComponent<AudioSource>().Play(); 
        Destroy(this.gameObject, 0.4f);
    }

    public float Speed = 100;

    private int Direction = 1;


    private void Movement()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        int rand = Random.Range(0, 20);
        
        if (rand < 10)
        {
            Direction *= -1;
        }

        float y = 0;
        if(rand < 5 && Mathf.Abs(rb.velocity.y) <= 0.02)
        {
            y = 30;
        }

        rb.AddForce(new Vector2(Direction * Speed, y));
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        float y = collision.GetContact(collision.contactCount - 1).normal.normalized.y;
        
        if (y <= -0.95)
        {
            print("kill");
            Kill();
        } else
        {
            print("dmg");
            collision.gameObject.GetComponent<HealthSystem>().TakeDamage();
        }
    }
}
