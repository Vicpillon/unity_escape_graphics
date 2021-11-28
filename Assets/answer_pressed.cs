using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answer_pressed : MonoBehaviour
{
    public static bool pressed = false;

    GameObject keypad; 
    // Start is called before the first frame update
    void Start()
    {
        keypad = GameObject.FindGameObjectWithTag("keypad");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!keypad.GetComponent<main_keypad>().open)
        {
            pressed = true;
        }
    }
}
