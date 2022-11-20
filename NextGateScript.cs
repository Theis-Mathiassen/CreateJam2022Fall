using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextGateScript : MonoBehaviour
{
    private GameObject Player;
    private PlayerController PC;
    private GameObject Camera;
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        Player = GameObject.Find("Player");
        PC = Player.GetComponent<PlayerController>();
    }
    void Update () {
        if (Player.transform.position.x > transform.position.x + 5) {
            SceneManager.LoadScene(nextLevel);
        }
        if (PC.Finish) {
            PC.rb.bodyType = RigidbodyType2D.Kinematic;
            PC.rb.velocity.Set(0, 0);
            if (Player.transform.position.y <= transform.position.y - 4.5) {
                print("test1");
                PC.rb.MovePosition(new Vector2(Player.transform.position.x + 0.05f, Player.transform.position.y));
            } else 
            {
                print("test2s");
                PC.rb.MovePosition(new Vector2(Player.transform.position.x, Player.transform.position.y - 0.1f));
            }
        }
    }
    
    public void OnTriggerEnter2D (Collider2D collider) {
        print("Trigger");
        if (collider.gameObject.CompareTag("Player")) {
            Camera.GetComponent<CameraController>().Follow = false;
            //Camera.transform.Translate(, .position.Set(transform.position.x - 5, transform.position.y - 5, -10);
            Camera.transform.position = new Vector3(transform.position.x +1, transform.position.y - 3, -10);
            PC.Finish = true;
            Player.GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x + 0.1f, Player.transform.position.y));
        }
    }


}
