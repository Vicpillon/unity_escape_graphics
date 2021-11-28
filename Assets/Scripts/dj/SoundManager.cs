using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public Slider backVolume;//slider
    public AudioSource audio;//audio manager obj
    public AudioMixer BGMmixer;


    private float backVol = 1f;

    public void SoundSlider()
    {
        float sound = backVolume.value;

        if (sound == -40f) BGMmixer.SetFloat("BGM", -80);
        else BGMmixer.SetFloat("BGM", sound);
   
    }
   
    // Start is called before the first frame update
    void Start()
    {

        backVol = PlayerPrefs.GetFloat("backVol", 1f);
        backVolume.value = backVol;
        audio.volume = backVolume.value;
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }
}
