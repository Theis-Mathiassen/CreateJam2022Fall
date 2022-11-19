using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteamPowerBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetSteamPower (float value) {
        value = value > 1 ? 1: value;
        value = value < 0 ? 0: value;
        slider.value = value;
    }
}
