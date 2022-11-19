using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitrogenCarriage : Carriage
{
    void Start () {
        print("StartNitro");
        //Texture2D texture = Resources.Load("Texture") as Texture2D;
        Sprite sprite = Resources.Load<Sprite>("Carriage");
        print(sprite);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    protected override void ApplyEffect()
    {
        
    }
    public override void StartEffect () {
        if (EffectActive == false) {
            Player.GetComponent<PlayerController>().EnginePower = 0;
            EffectActive = true;
            GetComponent<AudioSource>().Play();
            StartCoroutine("StopEffect");
        }
    }
    protected override IEnumerator StopEffect () {
        
        yield return new WaitForSeconds(5);

        if (EffectActive == true) {
            GetComponent<AudioSource>().Stop();
            EffectActive = false;
        }
    }
}
