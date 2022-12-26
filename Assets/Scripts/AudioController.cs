using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume")) audioSource.volume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = PlayerPrefs.GetFloat("volume");
    }
}
