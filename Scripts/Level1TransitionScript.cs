using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1TransitionScript : MonoBehaviour
{
    public void Nav () {
        SceneManager.LoadScene("Level2");
    }
}
