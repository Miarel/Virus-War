using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public float volume;
    void Start()
    {
        volume = slider.value;
        slider.value = volume;
        if (!PlayerPrefs.HasKey("volume")) slider.value = 1f;
        else
        {
            volume = PlayerPrefs.GetFloat("volume");
            slider.value = volume;
        }
    }
    void Update()
    {
        if (volume != slider.value)
        {
            PlayerPrefs.SetFloat("volume", slider.value);
            PlayerPrefs.Save();
            volume = slider.value;
            slider.value = volume;
        }
        else
        {
            slider.value = volume;
        }
    }
}
