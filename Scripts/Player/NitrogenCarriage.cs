using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitrogenCarriage : Carriage
{
    protected override void Start () {
        print("StartNitro");
        //Texture2D texture = Resources.Load("Texture") as Texture2D;
        base.Start();
    }
    protected override void ApplyEffect()
    {
        
    }
    public override void StartEffect () {
        if (EffectActive == false) {
            Player.GetComponent<PlayerController>().EnginePower = 0;
            base.StartEffect();
        }
    }
    protected override IEnumerator StopEffect () {
         
        yield return base.StopEffect();
    }
}
