using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2TransitionScript : MonoBehaviour
{
    public void Nav () {
        SceneManager.LoadScene("Level3");
    }
}
