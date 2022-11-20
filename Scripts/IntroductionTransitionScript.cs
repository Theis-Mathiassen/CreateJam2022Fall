using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionTransitionScript : MonoBehaviour
{
    public void Nav () {
        SceneManager.LoadScene("Level1");
    }
}
