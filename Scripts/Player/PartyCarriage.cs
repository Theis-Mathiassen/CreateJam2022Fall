using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyCarriage : Carriage
{
    bool val1 = false;
    bool val2 = false;
    

    protected override void Start () {
        base.Start();
        
        print("Party Start");
        
        print("Sprites: " + sprites);
        
    }
    protected override void ApplyEffect()
    {
        if (Time.frameCount % 2 == 0) {
            if (val1 = !val1) {
                People.GetComponent<SpriteRenderer>().sprite = sprites[2];
            } else {
                People.GetComponent<SpriteRenderer>().sprite = sprites[3];
            }
        }
        if (Time.frameCount % 3 == 0) {
            if (val2 = !val2) {
                Background.GetComponent<SpriteRenderer>().sprite = sprites[0];
            } else {
                Background.GetComponent<SpriteRenderer>().sprite = sprites[1];
            }
        }
        
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-20, 20), Random.Range(-60, 65)));
        //print("Tester");
    }
}
