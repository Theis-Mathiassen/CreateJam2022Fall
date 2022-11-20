using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterCarriage : Carriage
{
    protected override void ApplyEffect()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0));
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void StartEffect() {
        People.GetComponent<SpriteRenderer>().sprite =  sprites[5];
        base.StartEffect();
    }
}
