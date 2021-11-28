using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_script : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject keypad;
    AudioSource audio;
    void Start()
    {
        keypad = GameObject.FindGameObjectWithTag("keypad");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
  

    }
    private void OnMouseDown()
    {   if (!keypad.GetComponent<main_keypad>().open)
        {
            audio.Play();
            
        }
    }
}
