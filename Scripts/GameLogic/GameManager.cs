using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}