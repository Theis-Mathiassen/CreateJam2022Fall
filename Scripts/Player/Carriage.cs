using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

abstract public class Carriage : MonoBehaviour
{
    //public Transform target;
    //public float FollowSpeed;

    private bool IsExploded = false;

    public GameObject Player;
    public GameObject People;
    public GameObject Background;
    public Sprite[] sprites;

    protected bool EffectActive = false;

    

    // Start is called before the first frame update
    protected virtual void Start()
    {
        sprites = Resources.LoadAll<Sprite>("CarriageParty-Sheet");
        print(sprites);
        List<GameObject> children = GetAllChilds(this.gameObject);
        People = children[0];
        Background = children[1];
        Sprite sprite = Resources.Load<Sprite>("Carriage");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        People.GetComponent<SpriteRenderer>().sprite = sprites[4];
        Background.GetComponent<SpriteRenderer>().sprite = sprites[4];
        //StartEffect();
    }

    // Update is called once per frame
    protected virtual void Update()
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
            foreach(AudioSource AS in GetComponents<AudioSource>()) {
                print("Playing");
                AS.Play();
            }
            StartCoroutine("StopEffect");
        }
    }

    protected virtual IEnumerator StopEffect () {
        
        yield return new WaitForSeconds(5);

        if (EffectActive == true) {
            foreach(AudioSource AS in GetComponents<AudioSource>()) {
                print("Playing");
                AS.Stop();
            }
            People.GetComponent<SpriteRenderer>().sprite =  sprites[4];
            Background.GetComponent<SpriteRenderer>().sprite =  sprites[4];
            EffectActive = false;
        }
    }

    public bool IsEffectActive() {
        return EffectActive;
    }


    public List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i< Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }

    abstract protected void ApplyEffect ();

}
