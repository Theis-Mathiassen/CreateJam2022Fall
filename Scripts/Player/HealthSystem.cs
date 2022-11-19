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
        print(rb);
        GameObject prev = null;
        for (int i = 0; i < 3; i++) {
            Vector3 pos = transform.position + new Vector3(-CarriageOffset * i - firstCarriageOffset, 0, 0);
            print(pos);
            GameObject current = GameObject.Instantiate(CarriagePrefab, pos, new Quaternion());
            carriages.Add(current);
            if (i == 0) {
                current.GetComponent<HingeJoint2D>().connectedBody = rb;
            } else {
                current.GetComponent<HingeJoint2D>().connectedBody = prev.GetComponent<Rigidbody2D>();
            }

            prev = current;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage () {
        if (LastDamaged + ImmuneTime < Time.time) {
            carriages.RemoveAt(carriages.Count - 1);
            LastDamaged = Time.time;
        }
    }
}
