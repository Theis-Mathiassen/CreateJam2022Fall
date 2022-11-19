using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyCarriage : Carriage
{
    protected override void ApplyEffect()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-20, 20), Random.Range(-60, 65)));
        //print("Tester");
    }
}
