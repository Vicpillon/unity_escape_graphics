using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enter_script : MonoBehaviour
{
    public Text txt;
    public bool enter = false;

    GameObject keypad;

    // Start is called before the first frame update
    void Start()
    {
        keypad = GameObject.FindGameObjectWithTag("keypad");
    }

    // Update is called once per frame
    void Update()
    {
        if(answer_pressed.pressed && enter)
        {
            txt.text = "4";
        }
    }
    private void OnMouseDown()
    {
        if (!keypad.GetComponent<main_keypad>().open)
        {
            enter = true;

        }
    }
}
