using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenuFunctions : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume (float value) {
        audioMixer.SetFloat("Volume", value);
    }
    public void SetFullScreen (bool val) {
        Screen.fullScreen = val;
    }

    public void NavMainMenu () {
        SceneManager.LoadScene("StartMenu");
    }
}
