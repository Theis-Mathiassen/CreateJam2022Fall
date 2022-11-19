using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

abstract public class Carriage : MonoBehaviour
{
    //public Transform target;
    public float FollowSpeed;

    private bool IsExploded = false;

    public GameObject Player;

    protected bool EffectActive = false;

    // Start is called before the first frame update
    void Start()
    {
        //StartEffect();
    }

    // Update is called once per frame
    void Update()
    {
        //print(EffectActive);
        if (EffectActive) {
            ApplyEffect();
        }
        //transform.position = Vector3.Lerp(transform.position, target.position, FollowSpeed * Time.deltaTime);
    }

    public void Explode () {
        Destroy(GetComponent<HingeJoint2D>());
        Rigidbody2D rb= GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-5, 6) * rb.mass, 50 * rb.mass));
        IsExploded = true;
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (IsExploded) {
            print("Dead");
            Destroy(this.gameObject);
        }
    }

    public virtual void StartEffect () {
        if (EffectActive == false) {
            EffectActive = true;
            GetComponent<AudioSource>().Play();
            StartCoroutine("StopEffect");
        }
    }

    protected virtual IEnumerator StopEffect () {
        
        yield return new WaitForSeconds(5);

        if (EffectActive == true) {
            GetComponent<AudioSource>().Stop();
            EffectActive = false;
        }
    }

    abstract protected void ApplyEffect ();

}
