using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Update () {
        //print("Test");
        
    }

    void OnKeyDown(KeyDownEvent ev)
    {
        Debug.Log("KeyDown:" + ev.keyCode);
        Debug.Log("KeyDown:" + ev.character);
        Debug.Log("KeyDown:" + ev.modifiers);
    }
    void OnKeyUp(KeyUpEvent ev)
    {
        Debug.Log("KeyUp:" + ev.keyCode);
        Debug.Log("KeyUp:" + ev.character);
        Debug.Log("KeyUp:" + ev.modifiers);
        if (ev.keyCode == KeyCode.Escape) {
            if (SceneManager.GetActiveScene().name == "Level2") {
                SceneManager.LoadScene("Level1");
            } else {
                SceneManager.LoadScene("Level2");
            }
        }
    }
}