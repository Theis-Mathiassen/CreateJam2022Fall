using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamBehaviour : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Sin(transform.position.y*10) * Random.Range(-0.4f, 0.4f)* 10, 0));
        if (transform.position.y > 10) {
            Destroy(this.gameObject);
        }
    }
}
