using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public List<GameObject> carriages;
    public GameObject CarriagePrefab;

    public float ImmuneTime;
    private float LastDamaged;
    private bool Immune = false;

    public float firstCarriageOffset = 1.5f;
    public float CarriageOffset = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //print(rb);
        GameObject prev = null;
        for (int i = 0; i < 3; i++) {
            Vector3 pos = transform.position + new Vector3(-CarriageOffset * i - firstCarriageOffset, 0, 0);
            //print(pos);
            GameObject current = GameObject.Instantiate(CarriagePrefab, pos, new Quaternion());
            carriages.Add(current);
            if (i == 0) {
                current.AddComponent<BoosterCarriage>();
                current.GetComponent<Carriage>().Player = this.gameObject;
                current.GetComponent<HingeJoint2D>().connectedBody = rb;
            } else if(i==1) {
                current.AddComponent<PartyCarriage>();
                current.GetComponent<Carriage>().Player = this.gameObject;
                current.GetComponent<HingeJoint2D>().connectedBody = prev.GetComponent<Rigidbody2D>();
            }
             else if(i==2) {
                current.AddComponent<NitrogenCarriage>();
                current.GetComponent<Carriage>().Player = this.gameObject;
                current.GetComponent<HingeJoint2D>().connectedBody = prev.GetComponent<Rigidbody2D>();
            }

            prev = current;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -2){
            if (IsEffectActive() == false) {
                ApplyRandomCarriageEffect();
            }
            TakeDamage();
        }
    }


    public void TakeDamage () {
        if (LastDamaged + ImmuneTime < Time.time) {
            if (carriages.Count == 0) {
                //Destroy(this.gameObject);
                //Gameover


            } else {
                if (carriages.Count > 0) {
                    GameObject carriage = carriages[carriages.Count - 1];
                    carriages.Remove(carriage);
                    LastDamaged = Time.time;
                    ExplodeCarriage(carriage);
                }
            }
        }
    }


    public void ExplodeCarriage (GameObject carriage) {
        carriage.GetComponent<Carriage>().Explode();
    }

    public void ApplyRandomCarriageEffect () {
        carriages[Random.Range(0, carriages.Count)].GetComponent<Carriage>().StartEffect();
    }

    private bool IsEffectActive () {
        foreach (GameObject carriage in carriages) {
            if (carriage.GetComponent<Carriage>().IsEffectActive()) {
                return true;
            }
        }
        return false;
    }
}
